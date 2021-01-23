    public class A<T> where T : A
    {
         private event EventHandler<CustomEventArgs<T>> _someEvent;
    
         // An event accessor acts like the event but it can't be used
         // to raise the event itself. It's just an accessor like an special
         // event-oriented property (get/set)
         public event EventHandler<CustomEventArgs<T>> SomeEvent
         {
              add { _someEvent += value; }
              remove { _someEvent -= value; }
         }
    
         protected virtual void RaiseSomeEvent(CustomEventArgs<T> args)
         {
               // If C# >= 6
               _someEvent?.Invoke(this, args);
    
               // Or in C# < 6
               // if(_someEvent != null) _someEvent(this, args);
         }
    }
    public class B : A<B> 
    { 
          public void DoStuff()
          {
               // It's just about raising the event accessing the whole
               // protected method and give an instance of CustomEventArgs<B> 
               // passing current instance (i.e. this) to CustomEventArgs<T>
               // constructor.
               RaiseSomeEvent(new CustomEventArgs<B>(this));
          }
    }
