    class AppModel
    {
         public class AsyncFactory
         {
               public AsyncFactory(IDependency x, IDependency2 y)
               { 
                   CreateAsync = async() =>
                       new AppModel( x.CalculateA(await y.CalculateB()));
               }
               public Func<Task<AppModel> CreateAsync { get;}
         }
         private AppModel(A a) { ... }
    }
