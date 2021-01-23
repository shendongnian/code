    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
        private void OnTextBoxLoaded(object sender, RoutedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.KeyUp += (o, args) =>
                {
                    if (args.Key == VirtualKey.Enter)
                    {
                        TextBox originalSource = (TextBox)args.OriginalSource;
                        int index = 0;
                        var items = listView.Items;
                        if (items != null)
                        {
                            foreach (Item item in items)
                            {
                                if (originalSource.DataContext == item)
                                {
                                    break;
                                }
                                ++index;
                            }
                            index = (index + 1) % items.Count;
                            ListViewItem container = (ListViewItem)listView.ContainerFromIndex(index);
                            TextBox nextTextBox = FindVisualChild<TextBox>(container);
                            nextTextBox?.Focus(FocusState.Programmatic);
                        }
                    }
                };
        }
        private static T FindVisualChild<T>(DependencyObject parent) where T : DependencyObject
        {
            if (parent != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(parent); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(parent, i);
                    T candidate = child as T;
                    if (candidate != null)
                    {
                        return candidate;
                    }
                    T childOfChild = FindVisualChild<T>(child);
                    if (childOfChild != null)
                    {
                        return childOfChild;
                    }
                }
            }
            return default(T);
        }
