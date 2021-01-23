    public class FooBLL
    {
        private IKullanicDal _kullanicDal;
        private IUnitOfWork _unitOfWork;
        public FooBLL(IKullanicDal kullanicDal,IUnitOfWork unitOfWork)
        {
            _kullanicDal = kullanicDal;
            _unitOfWork = unitOfWork;
        }
    
        public void FooBusinessMethod()
        {
          _unitOfWork.Begin();
          //do something with dal
          //_unitOfWork.Commit etc
        }
    
    }
