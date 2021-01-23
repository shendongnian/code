        public class MYViewModel :ViewModelBase
    {
       public MyViewModel()
       {
           PickerCommand = new RelayCommand<object>(ActionForPickerCommand);
        }
        public ICommand PickerCommand {get;set;}
    }
