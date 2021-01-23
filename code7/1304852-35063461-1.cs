     try
                {                
    
                    string logFile = @"D:\TaskDev\Log4NetTesting\Log4NetTesting\bin\Debug\Test\Log4netTesting.Log";
                    log4net.GlobalContext.Properties["LogFileName"] = logFile;
                    log4net.Config.XmlConfigurator.Configure();
                    log4net.NDC.Push("Test Application");
                    ILog log = log4net.LogManager.GetLogger(typeof(Program));
                    var fileAppenders = LogManager.GetAllRepositories().SelectMany(repository => repository.GetAppenders()).OfType<FileAppender>();
    
                    var customLogErrorHandler = new CustomLogErrorHandler();  // custom error IErrorHandler. 
                    
                    // loop though fileappenders adding the error handler
                    foreach (var fileAppender in fileAppenders)
                    {
                        fileAppender.ErrorHandler = customLogErrorHandler;
                    }
                    log.Info("hello Log file");
    
                    if (customLogErrorHandler.message != null)   // if there is an error throw exception
                    {
                        throw new LogException(customLogErrorHandler.message, customLogErrorHandler.Exception, customLogErrorHandler.ErrorCode);
                    }
                }
                catch (LogException lex) {
                    // catch log exception
                    Console.WriteLine(lex.ErrorCode);
                    Console.WriteLine(lex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
