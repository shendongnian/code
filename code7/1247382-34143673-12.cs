    using log4net;
    using log4net.Appender;
    using log4net.Config;
    using log4net.Core;
    using log4net.Layout;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Xml.Linq;
    using System.Runtime.CompilerServices;
    using System.Diagnostics;
    using System.Security.AccessControl; // Used in IsWritable(directory)
    using System.Security.Principal; // Used in IsWritable(directory)
    
    namespace LogWrapper
    {
        public class LogConfig
        {
            /// <summary>
            /// Initializes a new LogConfig object, for use with initializing a new Logger
            /// </summary>
            public LogConfig(Type type, Assembly assem)
            {
                Type = type;
                EntryAssembly = assem;
            }
            private Type Type { get; set; }
            private Assembly assembly = Assembly.GetEntryAssembly();
            private Assembly EntryAssembly
            {
                get
                {
                    return assembly;
                }
                set
                {
                    if (assembly != null)
                        assembly = value;
                    this.Update();
                }
            }
            public bool AppendToFile { get; set; } = true;
            private string parentPath = String.Empty;
            /// <summary>
            /// This is the Path to the folder that will contain the 
            /// Configuation and Logs folder
            /// Recommended path is ProgramData\\CompanyName
            /// </summary>
            private string ParentPath
            {
                get
                {
                    if (String.IsNullOrEmpty(parentPath))
                    {
                        return Path.Combine(
                            ProgramData, // ProgramData
                            EntryAssembly.FullName.Split('.')[0]);
                    }
                    else
                    {
                        return parentPath;
                    }
                }
                set
                {
                    if (IsWritable(new DirectoryInfo(value)))
                    {
                        parentPath = value;
                    }
                    this.Update();
                }
            }
            private string _pattern = "%-5level\t%date{yyyy-MM-dd HH:mm:ss.fff}\t[%thread]\t%logger\t%message%newline";
            public string LogPattern
            {
                get
                {
                    return this._pattern;
                }
                set
                {
                    if (!String.IsNullOrEmpty(value))
                    {
                        this._pattern = value;
                        this.Update();
                    }
                }
            }
            public int MaxLogFiles = 5;
            public int MaxLogSizeInMB = 5;
            private Level _level = Level.Debug;
            public Level Level
            {
                get
                {
                    return this._level;
                }
                set
                {
                    _level = value;
                    this.Update();
                }
            }
            private string LogFilePath
            {
                get
                {
                    return Path.Combine(LogFolder,
                        EntryAssembly.GetName().Name
                        .ToFileName() + ".Log.csv");
                }
            }
            private string ConfigFilePath
            {
                get
                {
                    return Path.Combine(ConfigurationFolder,
                        Path.GetFileNameWithoutExtension(
                            EntryAssembly.Location
                        ).ToFileName() + ".Log4Net.config.xml");
                }
            }
    
            private string ConfigurationFolder
            {
                get
                {
                    return Path.Combine(this.ParentPath, "Configuration");
                }
            }
            private string LogFolder
            {
                get
                {
                    return Path.Combine(this.ParentPath, "Logs");
                }
            }
            private bool initialized = false;
            internal ILog Setup()
            {
                return this.Update(false);
            }
            internal ILog Update(bool overwrite = true)
            {
                if (!Directory.Exists(this.ParentPath))
                    Directory.CreateDirectory(this.ParentPath);
                if (!Directory.Exists(ConfigurationFolder))
                    Directory.CreateDirectory(ConfigurationFolder);
                if (!Directory.Exists(LogFolder))
                    Directory.CreateDirectory(LogFolder);
                if (!File.Exists(ConfigFilePath) || overwrite)
                {
                    var config = this.Serialize();
                    File.Create(ConfigFilePath).Close();
                    File.WriteAllText(ConfigFilePath, config.ToString());
                }
                var logger = LogManager.GetLogger(EntryAssembly, Type);
                XmlConfigurator.ConfigureAndWatch(new FileInfo(ConfigFilePath));
                if (!initialized)
                {
                    initialized = true;
                }
                return logger;
            }
            private XDocument Serialize()
            {
                XDocument xDoc = new XDocument();
    
                //apender
                var param = new XElement("param");
                param.SetAttributeValue("name", "ConversionPattern");
                param.SetAttributeValue("value", LogPattern);
    
                var layout = new XElement("layout", param);
                layout.SetAttributeValue("type", typeof(PatternLayout));
    
                var file = new XElement("file");
                file.SetAttributeValue("value", LogFilePath);
    
                var append = new XElement("appendToFile");
                append.SetAttributeValue("value", AppendToFile);
    
                var rollingstyle = new XElement("rollingStyle");
                rollingstyle.SetAttributeValue("value",
                    Enum.GetName(typeof(RollingFileAppender.RollingMode)
                        , RollingFileAppender.RollingMode.Size));
    
                var maxFiles = new XElement("maxSizeRollBackups");
                maxFiles.SetAttributeValue("value", MaxLogFiles);
    
                var maxFileSize = new XElement("maximumFileSize");
                maxFileSize.SetAttributeValue("value", "{0}MB".FormatWith(MaxLogSizeInMB));
    
                var staticLogFile = new XElement("StaticLogFileName");
                staticLogFile.SetAttributeValue("value", true);
    
                var appender = new XElement("appender"
                    , file
                    , append
                    , rollingstyle
                    , maxFiles
                    , maxFileSize
                    , staticLogFile
                    , layout);
                appender.SetAttributeValue("name", EntryAssembly.GetName().Name);
                appender.SetAttributeValue("type", typeof(RollingFileAppender));
    
                //Root
                var level = new XElement("level");
                level.SetAttributeValue("value", Level.Name);
                var appRef = new XElement("appender-ref");
                appRef.SetAttributeValue("ref", EntryAssembly.GetName().Name);
    
                var root = new XElement("root", level, appRef);
    
                //Config
                var section = new XElement("section");
                section.SetAttributeValue("name", "log4net");
                section.SetAttributeValue("type", "{0}, {1}".FormatWith(typeof(Log4NetConfigurationSectionHandler), "log4net"));
    
                var configSection = new XElement("configSections", section);
    
                var configuration = new XElement("configuration",
                    configSection,
                    new XElement("log4net",
                        appender, root));
    
                return XDocument.Parse(configuration.ToString());
            }
            //Helper Methods
            private static string ProgramData
            {
                get
                {
                    return Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
                }
            }
            private static bool IsWritable(DirectoryInfo destDir)
            {
                if (string.IsNullOrEmpty(destDir.FullName) || !Directory.Exists(destDir.FullName)) return false;
                try
                {
                    DirectorySecurity security = Directory.GetAccessControl(destDir.FullName);
                    SecurityIdentifier users = new SecurityIdentifier(WellKnownSidType.BuiltinUsersSid, null);
                    foreach (AuthorizationRule rule in security.GetAccessRules(true, true, typeof(SecurityIdentifier)))
                    {
                        if (rule.IdentityReference == users)
                        {
                            FileSystemAccessRule rights = ((FileSystemAccessRule)rule);
                            if (rights.AccessControlType == AccessControlType.Allow)
                            {
                                if (rights.FileSystemRights == (rights.FileSystemRights | FileSystemRights.Modify)) return true;
                            }
                        }
                    }
                    return false;
                }
                catch
                {
                    return false;
                }
            }
        }
        /// <summary>
        /// Log4Net wrapper, modified from codecampserver (http://code.google.com/p/codecampserver/source/list)
        /// </summary>
        public static partial class Log
        {
            private static readonly Dictionary<Assembly, Dictionary<Type, ILog>> _loggers = new Dictionary<Assembly, Dictionary<Type, ILog>>();
            private static bool _logInitialized;
            private static readonly object _lock = new object();
    
            public static string SerializException(Exception exception)
            {
                return SerializException(exception, string.Empty);
            }
    
            private static string SerializException(Exception e, string exceptionMessage)
            {
                if (e == null) return string.Empty;
    
                exceptionMessage = string.Format(CultureInfo.InvariantCulture,
                                                "{0}{1}{2}\n{3}",
                                                exceptionMessage,
                                                string.IsNullOrEmpty(exceptionMessage) ? string.Empty : "\n\n",
                                                e.Message,
                                                e.StackTrace);
    
                if (e.InnerException != null)
                    exceptionMessage = SerializException(e.InnerException, exceptionMessage);
    
                return exceptionMessage;
            }
    
            private static ILog getLogger(Type source, Assembly assem)
            {
                //EnsureInitialized(assem, source);
                lock (_lock)
                {
                    if (!_loggers.ContainsKey(assem))
                    {
                        _loggers.Add(assem, new Dictionary<Type, ILog>());
                    }
    
                    if (_loggers[assem] == null)
                    {
                        _loggers[assem] = new Dictionary<Type, ILog>();
                    }
    
                    if (!_loggers[assem].ContainsKey(source))
                    {
                        _loggers[assem].Add(source, new LogConfig(source, assem).Setup());
                    }
                    var logger = _loggers[assem][source];
                    return logger;
                }
            }
            public static void Debug(string message = "", Exception ex = null, [CallerMemberName] string methodName = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Debug(method.DeclaringType, "{0}()\t{1}".FormatWith(methodName, message.ToCSVFormat()), ex);
            }
            public static void Info(string message = "", Exception ex = null, [CallerMemberName] string methodName = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Info(method.DeclaringType, "{0}()\t{1}".FormatWith(methodName, message.ToCSVFormat()), ex);
            }
            public static void Warn(string message = "", Exception ex = null, [CallerMemberName] string methodName = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Warn(method.DeclaringType, "{0}()\t{1}".FormatWith(methodName, message.ToCSVFormat()), ex);
            }
            public static void Error(string message = "", Exception ex = null, [CallerMemberName] string methodName = "", [CallerFilePath] string file = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Error(method.DeclaringType, "{0}()\t{1} in {2}".FormatWith(methodName, message.ToCSVFormat(), file), ex);
            }
            public static void Error(Exception ex, [CallerMemberName] string methodName = "", [CallerFilePath] string file = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Error(method.DeclaringType, "{0}()\t{1} in {2}".FormatWith(methodName, ex.Message.ToCSVFormat(), file), ex);
            }
            public static void Fatal(string message = "", Exception ex = null, [CallerMemberName] string methodName = "", [CallerLineNumber] int line = -1, [CallerFilePath] string file = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Fatal(method.DeclaringType, "{0}()\t{1} at Line# {2} in [{3}]".FormatWith(methodName, message.ToCSVFormat()), ex);
            }
            public static void Fatal(Exception ex = null, [CallerMemberName] string methodName = "", [CallerLineNumber] int line = -1, [CallerFilePath] string file = "")
            {
                MethodBase method = new StackTrace().GetFrame(1).GetMethod();
                Fatal(method.DeclaringType, "{0}()\t{1} at Line# {2} in [{3}]".FormatWith(methodName, ex.Message.ToCSVFormat()), ex);
            }
            public static LogConfig Config
            {
                get
                {
                    return new LogConfig(MethodBase.GetCurrentMethod().DeclaringType, Assembly.GetEntryAssembly());
                }
                set
                {
                    _loggers[Assembly.GetEntryAssembly()][MethodBase.GetCurrentMethod().DeclaringType] = value.Update();
                }
            }
            /* Log a message object */
            private static void Debug(Type source, string message)
            {
                ILog logger = getLogger(source, Assembly.GetEntryAssembly());
                if (logger.IsDebugEnabled)
                    logger.Debug(message);
            }
            private static void Info(Type source, object message)
            {
                ILog logger = getLogger(source, Assembly.GetEntryAssembly());
                if (logger.IsInfoEnabled)
                    logger.Info(message);
            }
            private static void Warn(Type source, object message)
            {
                ILog logger = getLogger(source, Assembly.GetEntryAssembly());
                if (logger.IsWarnEnabled)
                    logger.Warn(message);
            }
            private static void Error(Type source, object message)
            {
                ILog logger = getLogger(source, Assembly.GetEntryAssembly());
                if (logger.IsErrorEnabled)
                    logger.Error(message);
            }
            private static void Fatal(Type source, object message)
            {
                ILog logger = getLogger(source, Assembly.GetEntryAssembly());
                if (logger.IsFatalEnabled)
                    logger.Fatal(message);
            }
    
            /* Log a message object and exception */
            private static void Debug(object source, object message, Exception exception)
            {
                Debug(source.GetType(), message, exception);
            }
            private static void Debug(Type source, object message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Debug(message, exception);
            }
            private static void Debug(Type source, string message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Debug(message, exception);
            }
            private static void Info(object source, object message, Exception exception)
            {
                Info(source.GetType(), message, exception);
            }
            private static void Info(Type source, object message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Info(message, exception);
            }
            private static void Info(Type source, string message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Info(message, exception);
            }
            private static void Warn(object source, object message, Exception exception)
            {
                Warn(source.GetType(), message, exception);
            }
            private static void Warn(Type source, object message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Warn(message, exception);
            }
            private static void Warn(Type source, string message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Warn(message, exception);
            }
            private static void Error(object source, object message, Exception exception)
            {
                Error(source.GetType(), message, exception);
            }
            private static void Error(Type source, object message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Error(message, exception);
            }
            private static void Error(Type source, string message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Error(message, exception);
            }
            private static void Fatal(object source, object message, Exception exception)
            {
                Fatal(source.GetType(), message, exception);
            }
            private static void Fatal(Type source, object message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Fatal(message, exception);
            }
            private static void Fatal(Type source, string message, Exception exception)
            {
                getLogger(source, Assembly.GetEntryAssembly()).Fatal(message, exception);
            }
            private static void initialize(Assembly assem, Type t)
            {
                _logInitialized = true;
            }
            private static void EnsureInitialized(Assembly assem, Type t)
            {
                if (!_logInitialized)
                {
                    initialize(assem, t);
                }
            }
        }
    }
