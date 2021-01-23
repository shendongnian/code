    public class Log : ILog
    {
    	public void Error(Exception exception)
    	{
    		log4net.ILog logger = log4net.LogManager.GetLogger(exception.TargetSite.DeclaringType);
    		logger.Error(exception.GetBaseException().Message, exception);
    	}
    
    	public void Error(string customMessage, Exception exception)
    	{
    		log4net.ILog logger = log4net.LogManager.GetLogger(exception.TargetSite.DeclaringType);
    		logger.Error(customMessage, exception);
    	}
    
    	public void Error(string format, Exception exception, params object[] args)
    	{
    		log4net.ILog logger = log4net.LogManager.GetLogger(exception.TargetSite.DeclaringType);
    		logger.Error(string.Format(format, args), exception);
    	}
    
    	public void Warn(Exception exception)
    	{
    		log4net.ILog logger = log4net.LogManager.GetLogger(exception.TargetSite.DeclaringType);
    		logger.Warn(exception.GetBaseException().Message, exception);
    	}
    
    	public void Info(string message)
    	{
    		log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    		logger.Info(message);
    	}
    }
