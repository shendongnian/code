    namespace MvvmLight1.ViewModel
    {
        public class MainViewModel : ViewModelBase
        {
            public MainViewModel()
            {
                LoadWindowCommand = new RelayCommand(OnLoadWindowCommand);
            }
            public RelayCommand LoadWindowCommand { get; private set; }
            private void OnLoadWindowCommand()
            {
                Debug.WriteLine("Loaded!");
            }
        }
    }
