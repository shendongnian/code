    class NotAControllerClass : NotAController
    {
        private readonly Your__DB__Context__Class _dbContext;
        public NotAControllerClass(Your__DB__Context__Class DbContext)
        {
            _dbContext = DbContext;
        }
    
        //do stuff here...
    }
