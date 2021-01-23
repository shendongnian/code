    public partial class MainWindow : Window
    {
        ...
        void SetBindings()
        {
            BindingOperations.ClearAllBindings(textA);
            BindingOperations.ClearAllBindings(textB);
            DataContext = null;
            Bind(textA, "A");
            Bind(textB, "B");
            DataContext = this;
        }
        void Bind(UIElement element, string name)
        {
            if (Config?.GetType().GetProperty(name, BindingFlags.Public | BindingFlags.Instance) != null)
            {
                BindingOperations.SetBinding(element, TextBox.TextProperty, new Binding("Config." + name));
                element.Visibility = Visibility.Visible;
            }
            else
                element.Visibility = Visibility.Collapsed;
        }
    }
