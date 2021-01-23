    public class MyModelViewModel : BindableBase
    {
          //...
          public void InnerStart()
          {
              model.Start();
              //Refresh the view model from the model
          }
          public MyModelViewModel ()
          {
            model = new MyModel ();
            Start  = InnerStart;
            CurrentOperationLabel = model.CurrentOperation; 
        }   
    }
