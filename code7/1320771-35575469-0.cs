        public interface IReusable
        {
         void doSomething();
        }
 
        public class Reusable: IReusable
        {
         public void doSomething()
         {
         //To Do: Some Stuff
         }
        }
 
        public class mySvcService
        {
         private IReusable _reuse;
 
         public void MethodOne(IReusable reuse)
         {
         this._reuse= reuse;
         _reuse.doSomething();
         }
         public void MethodTwo(IReusable reuse)
         {
         this._reuse= reuse;
         _reuse.doSomething();
         }
        }
