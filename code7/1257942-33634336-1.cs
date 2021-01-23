    public partial class MainWindow : Window
    {
        public class Category
        {
            public string CategoryName { get; set; }
        }
        public List<Category> categories = new List<Category>
        {
            new Category { CategoryName = "Category 1" },
            new Category { CategoryName = "Category 2" }
        };
        public MainWindow()
        {
            InitializeComponent();
            var textBlock = new FrameworkElementFactory(typeof(TextBlock));
            textBlock.SetBinding(TextBlock.TextProperty, new Binding("CategoryName"));
            var dataTemplate = new DataTemplate
            {
                VisualTree = textBlock
            };
            var categoryListBox = new ListBox
            {
                ItemTemplate = dataTemplate
            };
            BindingOperations.SetBinding(categoryListBox, ItemsControl.ItemsSourceProperty, new Binding
            {
                Source = categories
            });
            var grid = (Grid) this.Content;
            grid.Children.Add(categoryListBox);
        }
    }
