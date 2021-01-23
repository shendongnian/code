    public class SecondViewModel : INotifyPropertyChanged
    {
        public SecondViewModel()
        {
            FirstViewModel.MyPropertyChanged += OnMyPropertyChanged;
        }
        public void OnMyPropertyChanged(object obj)
        {
            //...
        }
        //....
    }
