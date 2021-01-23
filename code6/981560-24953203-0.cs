    class MyRepository {
        private IUnitOfWork _unitOfWork;
        
        public([Named("EF")] IUnitOfWork unitOfWork)
            _ = unitOfWork;
        }
    }
