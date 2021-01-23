    public partial class ElementHeaderUCEditor : UserControl, ITypeEditor
    {
        public ElementHeaderUCEditor()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(ElementListViewModel), typeof(ElementHeaderUCEditor),
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
            BindingOperations.SetBinding(this, ElementHeaderUCEditor.ValueProperty, binding);
            return this;
        }
    }
