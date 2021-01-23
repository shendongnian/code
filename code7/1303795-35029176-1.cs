    using System.Collections.ObjectModel;
    using System.Windows.Input;
    
    namespace WpfApplication4
    {
        public class MainViewModel
        {
            public ObservableCollection<string> Stuff { get; set; } = new ObservableCollection<string>();
    
            public ICommand GoCommand { get; set; }
            public string TextValue { get; set; }   
    
            public MainViewModel()
            {
                Stuff.Add("a");
                Stuff.Add("b");
                Stuff.Add("c");
                Stuff.Add("d");
    
                GoCommand = new RelayCommand((p) => Stuff.Add(TextValue));
            }
        }
    }
