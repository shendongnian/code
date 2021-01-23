    class MyRepository {
        private IUnitOfWork _unitOfWork;
        
        public([Named("EF")] IUnitOfWork unitOfWork)
            _unitOfWork = unitOfWork;
        }
    }
