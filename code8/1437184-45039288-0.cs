    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Logging;
    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace LogFileClearance
    {
    	public static class Marker
    	{
    		public static LogWriter customLogWriter { get; set; }
    	}
    
    	class Program
    	{
    		private static object _syncEventId = new object();
    		private static object locker = new object();
    		private static int _eventId = 0;
    		private const string INFO_CATEGORY = "All Events";
    
    		static void Main( string [] args )
    		{
    			InitializeLogger();
    			Console.WriteLine( "Enter some input, <Enter> or q to quit, c to clear the log file" );
    			string input = Console.ReadLine().ToUpper();
    			while ( ! string.IsNullOrEmpty(input) && input != "Q" )
    			{
    				Console.WriteLine( "You entered {0}", input );
    				if ( input == "C" )
    				{
    					ClearLog();
    				}
    				else
    				{
    					WriteLog( input );
    				}
    
    				Console.WriteLine( "Enter some input, <Enter> or q to quit, c to clear the log file" );
    				input = Console.ReadLine().ToUpper();
    			}
    		}
    
    		private static int GetNextEventId()
    		{
    			lock ( _syncEventId )
    			{
    				return _eventId++;
    			}
    		}
    
    		public static void InitializeLogger()
    		{
    			try
    			{
    				lock ( locker )
    				{
    					if ( Marker.customLogWriter == null )
    					{
    						var writer = new LogWriterFactory().Create();
    						Logger.SetLogWriter( writer, false );
    					}
    					else
    					{
    						Logger.SetLogWriter( Marker.customLogWriter, false );
    					}
    				}
    			}
    			catch ( Exception ex )
    			{
    				Debug.WriteLine( "An error occurred in InitializeLogger: " + ex.Message );
    			}
    		}
    
    		static internal void WriteLog( string message )
    		{
    			LogEntry logEntry = new LogEntry();
    			logEntry.EventId =  GetNextEventId();
    			logEntry.Severity = TraceEventType.Information;
    			logEntry.Priority = 2;
    			logEntry.Message = message;
    
    			logEntry.Categories.Add( INFO_CATEGORY );
    
    			// Always attach the version and username to the log message.
    			// The writeLog stored procedure will parse these fields.
    			Logger.Write( logEntry );
    		}
    
    		static internal void ClearLog()
    		{
    			string originalFileName = string.Format(@"C:\Logs\LogFileClearance.log");
    			string tempFileName = originalFileName.Replace( ".log", "(TEMP).log" );
    			var textFormatter = new FormatterBuilder()
    				.TextFormatterNamed( "Custom Timestamped Text Formatter" )
    				.UsingTemplate("{timestamp(local:MM/dd/yy hh:mm:ss.fff tt)} tid={win32ThreadId}: {message}");
    
    			#region Set the Logging LogWriter to use the temp file
    			var builder = new ConfigurationSourceBuilder();
    
    			builder.ConfigureLogging()
    				.LogToCategoryNamed( INFO_CATEGORY ).WithOptions.SetAsDefaultCategory()
    					.SendTo.FlatFile( "Flat File Trace Listener" )
    					.ToFile(tempFileName);
    
    			using ( DictionaryConfigurationSource configSource = new DictionaryConfigurationSource() )
    			{
    				builder.UpdateConfigurationWithReplace(configSource);
    				Marker.customLogWriter = new LogWriterFactory(configSource).Create();
    			}
    			InitializeLogger();
    			#endregion
    
    			#region Clear the original log file
    			if ( File.Exists(originalFileName) )
    			{
    				File.WriteAllText(originalFileName, string.Empty);
    			}
    			#endregion
    
    			#region Re-connect the original file to the log writer
    			builder = new ConfigurationSourceBuilder();
    
    			builder.ConfigureLogging()
    				.WithOptions.DoNotRevertImpersonation()
    				.LogToCategoryNamed( INFO_CATEGORY ).WithOptions.SetAsDefaultCategory()
    					.SendTo.RollingFile("Rolling Flat File Trace Listener")
    						.RollAfterSize(1000)
    					.FormatWith(textFormatter).WithHeader("").WithFooter("")
    					.ToFile(originalFileName);
    
    			using ( DictionaryConfigurationSource configSource = new DictionaryConfigurationSource() )
    			{
    				builder.UpdateConfigurationWithReplace( configSource );
    				Marker.customLogWriter = new LogWriterFactory( configSource ).Create();
    			}
    			InitializeLogger();
    			#endregion
    		}
    	}
    }
