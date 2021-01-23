    class AppModel
    {
         public class AsyncFactory : LazyTask<AppModel>
         {
               public AsyncFactory(IDependency x, IDependency2 y) : base(async() => 
                   new AppModel( x.CalculateA(await y.CalculateB())))
               {}
         }
         private AppModel(A a) { ... }
    }
