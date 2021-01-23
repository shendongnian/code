    class MyViewModel : INotifyPropertyChanged
    { 
         private class SendCommand : ICommand
         {
              private readonly MyViewModel _viewModel;
              public SendCommand(MyViewModel viewModel) 
              {
                  this._viewModel = viewModel; 
              }
              
              bool ICommand.CanExecute(object p) 
              {
                   return true;
              }
              void ICommand.Execute(object parameter)
              {
                   _viewModel.Send();
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
