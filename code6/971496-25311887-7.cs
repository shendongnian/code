    public partial class ElementUCEditor : UserControl, ITypeEditor
    {
        public ElementUCEditor()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(ElementListViewModel), typeof(ElementUCEditor),
                                                                                        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public ElementListViewModel Value
        {
            get { return (ElementListViewModel)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
        {
            Binding binding = new Binding("Value");
            binding.Source = propertyItem;
            binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            BindingOperations.SetBinding(this, ElementUCEditor.ValueProperty, binding);
            return this;
        }
    }
