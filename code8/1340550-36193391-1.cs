    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int theRowYouWant = 0;
            var listBoxItem = (ListBoxItem)MyListView.ItemContainerGenerator.ContainerFromIndex(theRowYouWant);
            var contentPresenter = FindVisualChild<ContentPresenter>(listBoxItem);
            var dataTemplate = contentPresenter.ContentTemplate;
            var txt = (TextBox)dataTemplate.FindName("GridTextBox", contentPresenter);
            ResultTextBlock.Text = txt.Text;
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
    }
