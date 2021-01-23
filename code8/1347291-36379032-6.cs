    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var vm = new ViewModel();
            this.stk.DataContext = vm;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //should be Command in MVVM, but this is just example to see that ObservableCollection works
            var btn = sender as Button;
            (btn.DataContext as ViewModel).Books.Add(new Book() { Name = "Book" + DateTime.Now.Second });
        }
    }
    public class ViewModel
    {
        public ViewModel()
        {
            this.Books = new ObservableCollection<Book>();
            this.Books.Add(new Book() { Name = "Book 1" });
            this.Books.Add(new Book() { Name = "Book 2" });
            this.Books.Add(new Book() { Name = "Book 3" });
        }
        public ObservableCollection<Book> Books { get; private set; }
    }
    public class Book
    {
        public string Name { get; set; }
    }
