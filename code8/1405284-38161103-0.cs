    class MyModel
    {
        public Schedule Schedule { get; set; }
        public Rates Rates { get; set; }
        public Balance Balance { get; set; }
    }
    
    class MyFileDataRepository
    {
        private IFileDataAccess _fileDataAccess;
    
        public MyFileDataRepository(IFileDataAccess fileDataAccess)
        {
            _fileDataAccess = fileDataAccess;
        }
    
        public Rates GetRates()
        {
            return _fileDataAccess.GetRates();
        }
    
        public Balance GetBalance()
        {
          return _fileDataAccess.GetBalance();
        }
    }
    
    class MyDbDataRepository
    {
        private IDbDataAccess _dbDataAccess;
    
        public MyDbDataRepository(IDbDataAccess dbDataAccess)
        {
            _dbDataAccess = dbDataAccess;
        }
    
        public Schedule GetSchedule()
        {
            return _dbDataAccess.GetSchedule();
        }
    }
    
    class MyModelProvider
    {
        private MyFileDataRepository _fileDataRepository;
        private MyDbDataRepository _dbDataRepository;
    
        public MyModelProvider(MyFileDataRepository fileDataRepository, MyDbDataRepository dbDataRepository)
        {
            _fileDataRepository = fileDataRepository;
            _dbDataRepository = dbDataRepository;
        }
    
        public MyModel GetModel()
        {
            return new MyModel
            {
                Schedule = _dbDataRepository.GetSchedule(),
                Rates = _fileDataRepository.GetRates(),
                Balance = _fileDataRepository.GetBalance()
            };
        }
      }
