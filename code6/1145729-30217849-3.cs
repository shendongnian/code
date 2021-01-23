    public class ViewModel : ViewModelBase
        {
            public ViewModel()
            {
                HideShowGraph = new RelayCommand<int>(foo => HideShowGraphExecute(foo));
            }
    
            public ICommand HideShowGraph { get; private set; }
    	
            private void HideShowGraphExecute(int foo)
            {
               //...evaluate foo
            }
        }
