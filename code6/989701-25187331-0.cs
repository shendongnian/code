    public class MyClassFactory : IMyClassFactory
    { 
        private readonly IMySingleton _mySingleton;
        private readonly IMyNonSingletonFactory _myNonSingletonFactory;
        public MyClassFactory(
            IMySingleton mySingleton, 
            IMyNonSingletonFactory myNonSingletonFactory
        )
        {
            _mySingleton = mySingleton;
            _myNonSingletonFactory = myNonSingletonFactory;
        }
        public IMyResult CreateMyResult(int resultId)
        {
            //you need your definition of INonSingletonFactory
            return new MyResult(_mySingleton, _myNonSingletonFactory.Create(), resultId);
        }
    } 
