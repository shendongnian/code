    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitTooltips(this);
        }
        private void InitTooltips(FrameworkElement element)
        {
            foreach (FrameworkElement child in
                LogicalTreeHelper.GetChildren(element).OfType<FrameworkElement>())
            {
                Label label = child as Label;
                if (label != null)
                {
                    BindingExpression bindingExpression =
                        BindingOperations.GetBindingExpression(label, Label.TargetProperty);
                    if (bindingExpression != null)
                    {
                        TextBox textBox =
                            FindName(bindingExpression.ParentBinding.ElementName) as TextBox;
                        if (textBox != null)
                        {
                            // You could just set the value, as here:
                            //textBox.ToolTip = label.Content;
                            // Or actually bind the value, as here:
                            Binding binding = new Binding();
                            binding.Source = label;
                            binding.Path = new PropertyPath("Content");
                            binding.Mode = BindingMode.OneWay;
                            BindingOperations.SetBinding(
                                textBox, TextBox.ToolTipProperty, binding);
                        }
                    }
                }
                InitTooltips(child);
            }
        }
    }
