    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Security;
    using BuildMan.Classes;
    using Microsoft.Build.Execution;
    using Microsoft.Build.Framework;
    using Microsoft.Build.Utilities;
    
    namespace JustBuild
    {
      public struct ProjectOutputTimeStamp
      {
        public string ProjectName;
        public DateTime OutputDateTime_BeforeBuild;
        public DateTime OutputDateTime_AfterBuild;
      }
    
      public class CRMBuildLogger : Logger
      {
        public List<string> Errors = new List<string>();
        public List<string> Warnings = new List<string>();
        public List<string> Messages = new List<string>();
        public List<ProjectOutputTimeStamp> outputs = new List<ProjectOutputTimeStamp>();
    
        public BuildResult BuildResult;
        /// <summary>
        /// Initialize is guaranteed to be called by MSBuild at the start of the build
        /// before any events are raised.
        /// </summary>
        public override void Initialize(IEventSource eventSource)
        {
          if (null == Parameters)
          {
            throw new LoggerException("Log file was not set.");
          }
          string[] parameters = Parameters.Split(';');
    
          string logFile = parameters[0];
          if (String.IsNullOrEmpty(logFile))
          {
            throw new LoggerException("Log file was not set.");
          }
    
          if (parameters.Length > 1)
          {
            throw new LoggerException("Too many parameters passed.");
          }
    
          try
          {
            // Open the file
            streamWriter = new StreamWriter(logFile);
          }
          catch (Exception ex)
          {
            if
            (
              ex is UnauthorizedAccessException
              || ex is ArgumentNullException
              || ex is PathTooLongException
              || ex is DirectoryNotFoundException
              || ex is NotSupportedException
              || ex is ArgumentException
              || ex is SecurityException
              || ex is IOException
            )
            {
              throw new LoggerException("Failed to create log file: " + ex.Message);
            }
            // Unexpected failure
            throw;
          }
    
          // For brevity, we'll only register for certain event types. Loggers can also
          // register to handle TargetStarted/Finished and other events.
          if (eventSource == null) return;
          eventSource.ProjectStarted += eventSource_ProjectStarted;
          eventSource.MessageRaised += eventSource_MessageRaised;
          eventSource.WarningRaised += eventSource_WarningRaised;
          eventSource.ErrorRaised += eventSource_ErrorRaised;
          eventSource.ProjectFinished += eventSource_ProjectFinished;
        }
    
        void eventSource_ErrorRaised(object sender, BuildErrorEventArgs e)
        {
          // BuildErrorEventArgs adds LineNumber, ColumnNumber, File, amongst other parameters
          string line = String.Format(": ERROR {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
          Errors.Add(line);
          WriteLineWithSenderAndMessage(line, e);
        }
    
        void eventSource_WarningRaised(object sender, BuildWarningEventArgs e)
        {
          // BuildWarningEventArgs adds LineNumber, ColumnNumber, File, amongst other parameters
          string line = String.Format(": Warning {0}({1},{2}): ", e.File, e.LineNumber, e.ColumnNumber);
          Warnings.Add(line);
          WriteLineWithSenderAndMessage(line, e);
        }
    
        void eventSource_MessageRaised(object sender, BuildMessageEventArgs e)
        {
          // BuildMessageEventArgs adds Importance to BuildEventArgs
          // Let's take account of the verbosity setting we've been passed in deciding whether to log the message
          if ((e.Importance == MessageImportance.High && IsVerbosityAtLeast(LoggerVerbosity.Minimal))
            || (e.Importance == MessageImportance.Normal && IsVerbosityAtLeast(LoggerVerbosity.Normal))
            || (e.Importance == MessageImportance.Low && IsVerbosityAtLeast(LoggerVerbosity.Detailed))
            )
          {
            Messages.Add(e.Message);
            WriteLineWithSenderAndMessage(String.Empty, e);
          }
        }
    
        void eventSource_ProjectStarted(object sender, ProjectStartedEventArgs e)
        {
          int idx = IndexOfProjectTimeStamp(e.ProjectFile);
          DateTime outputfiledatetime = DateTime.MinValue;
          StudioProject proj = new StudioProject(e.ProjectFile);
          FileInfo outputFile;
          if (File.Exists(e.ProjectFile))
          {
            outputFile = new FileInfo(proj.OutputFile());
            outputfiledatetime = outputFile.LastWriteTime;
          }
    
          //keep track of the mod date/time of the project output.
          //if the mod date changes as a result of the build, then that means the project changed.
          //this is necessary because the MSBuild engine doesn't tell us which projects were actually recompiled during a "build".
          //see also: http://stackoverflow.com/questions/34903800
          ProjectOutputTimeStamp p = new ProjectOutputTimeStamp()
          {
            OutputDateTime_BeforeBuild = outputfiledatetime,
            ProjectName = e.ProjectFile,
            OutputDateTime_AfterBuild = DateTime.MinValue
          };
          if (-1 == idx)
            outputs.Add(p);
          else
            outputs[idx] = p;
    
          WriteLine(String.Empty, e);
          indent++;
        }
    
        private int IndexOfProjectTimeStamp(string projectname)
        {
          for (int i = 0; i < outputs.Count; ++i)
            if (outputs[i].ProjectName.ToUpper() == projectname.ToUpper())
              return i;
          return -1;
        }
    
        void eventSource_ProjectFinished(object sender, ProjectFinishedEventArgs e)
        {
          int idx = IndexOfProjectTimeStamp(e.ProjectFile);
          DateTime outputfiledatetime = DateTime.MinValue;
          StudioProject proj = new StudioProject(e.ProjectFile);
          FileInfo outputFile;
          if (File.Exists(e.ProjectFile))
          {
            outputFile = new FileInfo(proj.OutputFile());
            outputfiledatetime = outputFile.LastWriteTime;
          }
    
          //keep track of the mod date/time of the project output.
          //if the mod date changes as a result of the build, then that means the project changed.
          //this is necessary because the MSBuild engine doesn't tell us which projects were actually recompiled during a "build".
          //see also: http://stackoverflow.com/questions/34903800
          ProjectOutputTimeStamp p = outputs[idx];
          p.OutputDateTime_AfterBuild = outputfiledatetime;
    
          if (-1 < idx)
            outputs[idx] = p;
    
          indent--;
          WriteLine(String.Empty, e);
        }
    
        public List<string> RecompiledProjects()
        {
          //let callers ask "which projects were actually recompiled" and get a list of VBPROJ files.
          List<string> result = new List<string>();
          foreach (ProjectOutputTimeStamp p in outputs)
          {
            if(p.OutputDateTime_AfterBuild>p.OutputDateTime_BeforeBuild)
              result.Add(p.ProjectName);
          }
          return result;
        } 
    
        /// <summary>
        /// Write a line to the log, adding the SenderName and Message
        /// (these parameters are on all MSBuild event argument objects)
        /// </summary>
        private void WriteLineWithSenderAndMessage(string line, BuildEventArgs e)
        {
          if (0 == String.Compare(e.SenderName, "MSBuild", StringComparison.OrdinalIgnoreCase))
          {
            // Well, if the sender name is MSBuild, let's leave it out for prettiness
            WriteLine(line, e);
          }
          else
          {
            WriteLine(e.SenderName + ": " + line, e);
          }
        }
    
        /// <summary>
        /// Just write a line to the log
        /// </summary>
        private void WriteLine(string line, BuildEventArgs e)
        {
          for (int i = indent; i > 0; i--)
          {
            streamWriter.Write("\t");
          }
          streamWriter.WriteLine(line + e.Message);
        }
    
        /// <summary>
        /// Shutdown() is guaranteed to be called by MSBuild at the end of the build, after all 
        /// events have been raised.
        /// </summary>
        public override void Shutdown()
        {
          // Done logging, let go of the file
          streamWriter.Close();
        }
    
        private StreamWriter streamWriter;
        private int indent;
      }
    }
