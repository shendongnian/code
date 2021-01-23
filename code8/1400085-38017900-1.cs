    public class Product : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private int count = 0;
        public int Count
        {
            get { return count; }
            set
            {
                if (value == count) return;
                count = value;
                if (null == PropertyChanged) return;
                PropertyChanged(this, new PropertyChangedEventArgs("Count"));
            }
        }
    }
    class SimpleCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        public bool CanExecute(object parameter) { return true; }
        private Action<T> execute;
        public SimpleCommand(Action<T> execute) { this.execute = execute; }
        public void Execute(object parameter) { execute((T)parameter); }
    }
    public partial class MainWindow : Window
    {
        public Product Cola { get; set; }
        public ICommand ProductInc { get { return new SimpleCommand<Product>(OnProductInc); } }
        public ICommand ProductDec { get { return new SimpleCommand<Product>(OnProductDec); } }
        private void OnProductInc(Product product) { ++product.Count; }
        private void OnProductDec(Product product) { --product.Count; }
        public MainWindow()
        {
            Cola = new Product { Count = 0 };
            this.DataContext = this;
            InitializeComponent();
        }
    }
