    public class MyClass {
       public event EventHandler SomeAction;
    
       private void DoStuff() {
           bool fireAction = false;
           //....
           if (fireAction) {
              EventArgs e = ...; // can be more specific if needed
              OnSomeAction(e);
           }
       }
    
       protected virtual void OnSomeAction(EventArgs e) {
         if (SomeAction != null)
             SomeAction(this, e);
       }
    }
    public class MySubclass : MyClass {
       protected override void OnSomeAction(EventArgs e) {
          // code before event is triggered
          base.OnSomeAction(e); // fires event to listeners
          // code after event is triggered
       }
    
    }
