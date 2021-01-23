    public class StatisticsLogger : IStatisticsLogger 
    {
        public StatisticsLogger(ILog logger)
        {
                this._logger =  logger; 
        }
        private readonly ILog _logger; 
        // implements ILog 
        public virtual void Info(Object message)
        {
            this._logger.info(message); 
        }
        // etc. 
    }
