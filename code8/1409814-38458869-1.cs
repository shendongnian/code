    namespace StkOverflow
    {
    public partial class MainWindow
    {
        public List<string> MyListItems
        {
            get { return (List<string>)GetValue(MyListItemsProperty); }
            set { SetValue(MyListItemsProperty, value); }
        }
        public static readonly DependencyProperty MyListItemsProperty =
            DependencyProperty.Register("MyListItems", typeof(List<string>), typeof(MainWindow), new PropertyMetadata(new List<string>() { "red", "orange", "green" }));
        
        public string TextToShow
        {
            get { return (string)GetValue(TextToShowProperty); }
            set { SetValue(TextToShowProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TextToShow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextToShowProperty =
            DependencyProperty.Register("TextToShow", typeof(string), typeof(MainWindow), new PropertyMetadata(""));
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;           
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextToShow = (sender as TextBlock).Text;
        }
        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextToShow = "";
        }
    }
    }
