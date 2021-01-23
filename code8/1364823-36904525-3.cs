    class MyViewModel : INotifyPropertyChanged
    { 
         private class SendCommand : ICommand
         {
              private readonly MyViewModel _viewModel;
              public SendCommand(MyViewModel viewModel) 
              {
                  this._viewModel = viewModel; 
              }
              
              void ICommand.Execute(object parameter)
              {
                   _viewModel.Send();
              }
              bool ICommand.CanExecute(object p) 
              {
                   // Could ask the view nodel if it is able to execute
                   // the command at this moment
                   return true;
              }
         }
         public ICommand SendCommand
         {
               get
               {
                   return new SendCommand(this);
               }
         }
         internal void Send() 
         {
              // Invoked by your command class
         }
    }
