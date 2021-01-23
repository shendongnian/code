    namespace M2E.Common.Logger
    {
    public class Logger : ILogger
    {
        private string _currentClassName;        
        bool GALoggin;
        ILog logger = null;
        public Logger(string currentClassName)
        {
            this._currentClassName = currentClassName;
            GALoggin = Convert.ToBoolean(ConfigurationManager.AppSettings["GALogging"]);
            
            logger = LogManager.GetLogger(_currentClassName);
            BasicConfigurator.Configure();
            log4net.Config.XmlConfigurator.Configure();
              
                       
        }
        public void Info(string message)
        {
            if (GALoggin && Convert.ToBoolean(ConfigurationManager.AppSettings["GAInfoLogging"]))
            {                
                TrackGoogleEvents("Logger-Info", "Info", message);               
            }
            else
            {
                logger.Info(message);
            }
        }
        public void Error(string message, Exception ex)
        {
            if (GALoggin)
            {
                TrackGoogleEvents("Logger-Error", message, ex.Message.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                logger.Error(message, ex);
            }
            try
            {
                SendAccountCreationValidationEmail.SendExceptionEmailMessage(
                    ConfigurationManager.AppSettings["ExceptionsSendToEmail"].ToString(CultureInfo.InvariantCulture),ex.Message);
            }
            catch (Exception)
            {
                         
            }
        }
        public void Debug(string message, Exception ex)
        {
            if (GALoggin)
            {
                TrackGoogleEvents("Logger-Debug", message, ex.Message.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                logger.Debug(message, ex);
            }                  
        }
        public void Fatal(string message, Exception ex)
        {
            if (GALoggin)
            {
                TrackGoogleEvents("Logger-Fatal", message, ex.Message.ToString(CultureInfo.InvariantCulture));
            }
            else
            {
                logger.Fatal(message, ex);
            }              
        }
        private void TrackGoogleEvents(string category, string action, string label)
        {
            try
            {
                AsyncTrackGoogleEvents(category, action, label); // to make it async call if required..
            }
            catch (Exception ex)
            {
                logger.Fatal("Google Analytics Event Tracking Exception", ex);
            }
            
        }
        public void AsyncTrackGoogleEvents(string category, string action, string label)
        {
            var googleEvent = new GoogleEvent("MadeToEarn.com", category, action, label, 1);
            var requestEvent = new RequestFactory().BuildRequest(googleEvent);
            GoogleTracking.FireTrackingEvent(requestEvent);
        }
    }
    }
