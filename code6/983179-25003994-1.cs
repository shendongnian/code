    public class MyServiceFactory : IMyServiceFactory // an interface to me able to mock it if needed
    {
        ISerializer _serializer;
        MyServiceFactory(ISerializer serializer){  // here Ninject can inject the dependency
            _serializer = serializer;
        }
        IMyService Create(int dataId){ // here you can pass additional parameter
            return new MyService(dataId, _serializer);
        }
    }
