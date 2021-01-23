     class ViewModel
     {
         public event EventHandler SomethingChanged;
         public int X
         {
             get { return _x; }
             set 
             {
                 _x = value;
                 _xSquared = _a * _a;
                 SomethingChanged(this, EventArgs.Empty);
             }
         }
         public int XSquared { get { return _xSquared; }
     }
     public class ExecutionManager
     {
         private ViewModel _viewModel;
         public void OnSomethingChanged(...)
         {
             // state is now consistent so long as everything is 
             // single threaded.
             ReconfigureHardware(_viewModel.X, _viewModel.XSquared);      
         }
     }
