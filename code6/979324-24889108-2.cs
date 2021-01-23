    Interface ILifeCycle
    {
      void OnCreated(...);
      void OnModified(...);
      ...
    } 
    [Export(typeof(ILifeCycle))] //export our classes for injection
    classB : ILifeCycle{
       public void OnCreated(...)
       {
           ....
       }
       public void OnModified(...){
       }
    }
    [Export(typeof(ILifeCycle))] //export our classes for injection
    classC : ILifeCycle{
       public void OnCreated(...)
       {
           ....
       }
       public void OnModified(...){
       }
    }
    classA
    {
      [ImportMany] //get all exported classes for injection
      private IList<ILifeCycle> _observers;
      protecetd void OnCreated()
      {
         //use MEF to build composition and then do the following
  
         foreach(var o in _observers){
            o.OnCreated(...);
         }
      }
      protecetd void OnModified()
      {
         //use MEF to build composition and then do the following
         foreach(var o in _observers){
            o.OnModified(...);
         }
      }
      ...
    }
