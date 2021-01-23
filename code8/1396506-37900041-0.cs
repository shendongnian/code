    public class MyService : IMyService
    {
        private IObserverManager observerManager;
    
        public MyService(IObserverManager obsManager){
                 this.observerManager = obsManager;
        }
    
        public void MyMethod(MyObject myObject){
    
            IObserver[] observers = this.observerManager.GetObservers();
            foreach(var ob in observers){
                   ob.Execute(myObject);
            }
        }
    }
    
    public class ObserverManager : IObserverManager {
        public List<IObserver> GetObservers(){
            ... some code to return the list of observers
        }
    
        public void RegisterObserver(IObserver obs)
        {
            ... add obs to list of obs
        }
    }
    
    public class Ob1 : IObserver{
          public void Execute(MyObject obj){
               //do something
           }
    }
    
    public class Ob2 : IObserver{
          public void Execute(MyObject obj){
               //do something
           }
    }
    
    public class StrategyResolver : IStrategyResolver
    {
        private IUnityContainer container;
        public StrategyResolver(IUnityContainer c)
        {
             this.container = c;
        }
        public T Resolve<T>(String namedStrategy){
             return this.container.Resolve<T>(namedStrategy); 
        }
    }
    public class MyRegistry : UnityRegistry
    {
        private IUnityContainer container;
      
        public MyRegistry(IUnityContainer c)
        {
           this.container = c;
        }
    
        public MyRegistry(){
            this.container.RegisterType<IObserverManager, ObserverManager>();
            this.container.RegisterType<IMyService, MyService();
            this.container.RegisterType<ISomeClass, SomeClass>();
            this.container.RegisterType<IObserver, ObserverA>("CategoryA");
            this.container.RegisterType<IObserver, ObserverB>("CategoryB");
            this.container.RegisterType<IStrategyResolver, StrategyResolver>();
        }
    }
    public class SomeClass : ISomeClass
    {
         private IObserverManager observerManager;
         private IStrategyResolver strategyResolver;
         public SomeClass(IObserverManager oManager, IStrategyResolver sResolver)
         {
             this.observerManager = oManager;
             this.strategyResolver = sResolver;
         }
  
         public void Process(MyObject obj)
         {
             IObserver obs = this.strategyResolver.Resolve<IObserver>(obj.Category);
             this.observerManager.RegisterObserver(obs);
             ...etc....
         }
    }
