    public class StudentViewModel : ViewModelBase
    {
        public StudentViewModel 
        {
           ButtonCommand = //Initilaize it with relay command class.
        }
        //... Other stuff goes here
    
        ICommand ButtonCommand { get; private set; }
    
        private  void OnButtonCommand()
        {
           NotifyPropertyChanged("FullName");
        }
    
    }
