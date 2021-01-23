    using Prism.Mvvm;
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace YourApplication
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainWindowViewModel();
            }
    
            private void dgNumbers_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
            {
                foreach (var item in (DataContext as MainWindowViewModel).LstOperations)
                {
                    item.Result = item.N1 + item.N2;
                }
            }
        }
    
        public class MainWindowViewModel : BindableBase
        {
            private ObservableCollection<Numbers> _lstOperations;
    
            public ObservableCollection<Numbers> LstOperations
            {
                get { return _lstOperations; }
                set
                {
                    _lstOperations = value;
                    OnPropertyChanged();
                }
            }
    
            public MainWindowViewModel()
            {
                _lstOperations = new ObservableCollection<Numbers>();
                Numbers n = new Numbers
                {
                    N1 = 10,
                    N2 = 5,
                    Result = 15
                };
                LstOperations.Add(n);
            }
        }
    
        public class Numbers : BindableBase
        {
            private decimal _n1;
            public decimal N1
            {
                get { return _n1; }
                set { SetProperty(ref _n1, value); }
            }
    
            private decimal _n2;
            public decimal N2
            {
                get { return _n2; }
                set { SetProperty(ref _n2, value); }
            }
    
            private decimal _result;
            public decimal Result
            {
                get { return _result; }
                set { SetProperty(ref _result, value); }
            }
        }
    }
