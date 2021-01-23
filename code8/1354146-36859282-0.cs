    using System;
    using System.Data;
    using log4net;
    using log4net.Repository.Hierarchy;
    using log4net.Core;
    using log4net.Appender;
    using log4net.Layout;
    [assembly: log4net.Config.XmlConfigurator( Watch = true )]
    namespace log
    {
        public class LoggerLib
        {
            int i = 0;
            public log4net.ILog logger;
            public void DeclareClass( System.Type className ) { logger =    log4net.LogManager.GetLogger( className ); }
            public void LogError(string content, string customContent1)
            {
                log4net.LogicalThreadContext.Properties["CustomColumn1"] =   customContent1;
                logger.Error( content );
            }
        public void LoggerSetup(string SQLServer, string SQLDatenBank, string SQLTable, string customContent2) 
        {
            if ( i == 0 )
            {
                RawLayoutConverter rlc = new RawLayoutConverter();
                AdoNetAppender adoNet = new AdoNetAppender();
                AdoNetAppenderParameter logDate = new AdoNetAppenderParameter();
                AdoNetAppenderParameter thread = new AdoNetAppenderParameter();
                AdoNetAppenderParameter logLevel = new AdoNetAppenderParameter();
                AdoNetAppenderParameter logLogger = new AdoNetAppenderParameter();
                AdoNetAppenderParameter message = new AdoNetAppenderParameter();
                AdoNetAppenderParameter exception = new AdoNetAppenderParameter();
                AdoNetAppenderParameter customColoumn1 = new AdoNetAppenderParameter();
                AdoNetAppenderParameter customColoumn2 = new AdoNetAppenderParameter();
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
                hierarchy.Root.AddAppender( adoNet );
                hierarchy.Root.Level = Level.All;
                hierarchy.Configured = true;
                log4net.Config.BasicConfigurator.Configure( adoNet );
                //logDate
                logDate.ParameterName = "@log_date";
                logDate.DbType = System.Data.DbType.DateTime;
                logDate.Layout = new RawTimeStampLayout();
                //thread
                thread.ParameterName = "@thread";
                thread.DbType = System.Data.DbType.String;
                thread.Size = 255;
                thread.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%thread" ) );
                //logLevel
                logLevel.ParameterName = "@log_level";
                logLevel.DbType = System.Data.DbType.String;
                logLevel.Size = 50;
                logLevel.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%level" ) );
                //logLogger
                logLogger.ParameterName = "@logger";
                logLogger.DbType = System.Data.DbType.String;
                logLogger.Size = 255;
                logLogger.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%logger" ) );
                //message
                message.ParameterName = "@message";
                message.DbType = System.Data.DbType.String;
                message.Size = 4000;
                message.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%message" ) );
                //exception
                exception.ParameterName = "@exception";
                exception.DbType = System.Data.DbType.String;
                exception.Size = 2000;
                exception.Layout = (IRawLayout)rlc.ConvertFrom( new ExceptionLayout() );
                //customColoumn1
                customColoumn1.ParameterName = "@customValue1";
                customColoumn1.DbType = System.Data.DbType.String;
                customColoumn1.Size = 2000;
                customColoumn1.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%property{CustomColumn1}" ) );
                //customColoumn2
                customColoumn2.ParameterName = "@customValue2";
                customColoumn2.DbType = System.Data.DbType.String;
                customColoumn2.Size = 2000;
                customColoumn2.Layout = (IRawLayout)rlc.ConvertFrom( new PatternLayout( "%property{CustomColumn2}" ) );
                adoNet.BufferSize = 1;
                adoNet.CommandType = System.Data.CommandType.Text;
                adoNet.ConnectionType = "System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
                adoNet.ConnectionString = "data source=" + SQLServer + "; initial catalog=" + SQLDatenBank + ";integrated security=true";
                adoNet.CommandText = "INSERT INTO " + SQLTable + " ([Date],[Thread],[Level],[Logger],[Message],[Exception],[CustomColoumn1],[CustomColoumn2]) VALUES (@log_date, @thread, @log_level, @logger, @message, @exception, @customValue1, @customValue2)";
                adoNet.AddParameter( logDate );
                adoNet.AddParameter( thread );
                adoNet.AddParameter( logLevel );
                adoNet.AddParameter( logLogger );
                adoNet.AddParameter( message );
                adoNet.AddParameter( exception );
                adoNet.AddParameter( customColoumn1 );
                adoNet.AddParameter( customColoumn2 );
                adoNet.ActivateOptions();
                log4net.LogicalThreadContext.Properties["CustomColumn2"] = customContent2;
                    i = 1;
                } 
                else
                {
                    log4net.LogicalThreadContext.Properties["CustomColumn2"] = customContent2;
                }
            }
        }
    }
    
