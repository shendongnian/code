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
