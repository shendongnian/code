    public class VisibilityData : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _visible = true;
        public bool Visible
        {
            get { return this._visible; }
            set
            {
                if (this._visible != value)
                {
                    this._visible = value;
                    if (this.PropertyChanged != null)
                    {
                        this.PropertyChanged(this, new PropertyChangedEventArgs("Visible"));
                    }
                }
            }
        }
    }
    public class ExtendedDataGridTextColumn : DataGridTextColumn
    {
        public Visibility MyVisibility
        {
            get
            {
                return (Visibility)GetValue(MyVisibilityProperty);
            }
            set
            {
                SetValue(MyVisibilityProperty, value);
            }
        }
        public static readonly DependencyProperty MyVisibilityProperty = DependencyProperty.Register("MyVisibility", typeof(Visibility), typeof(ExtendedDataGridTextColumn), new PropertyMetadata(MyVisibilityChanged));
        private static void MyVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var n = d as ExtendedDataGridTextColumn;
            if (n != null && e.NewValue is Visibility)
            {
                n.Visibility = (Visibility)e.NewValue;
            }
        }
        public ExtendedDataGridTextColumn()
        {
        }
    }
    public class CustomDataGridTemplateColumn : DataGridTemplateColumn
    {
        public static readonly DependencyProperty VisibilityBindingProperty = DependencyProperty.Register(
          "VisibilityBinding", typeof(Visibility), typeof(CustomDataGridTemplateColumn), new PropertyMetadata(Visibility.Collapsed, new PropertyChangedCallback(OnVisibilityChanged)));
        public Visibility VisibilityBinding
        {
            get { return (Visibility)this.GetValue(VisibilityBindingProperty); }
            set { this.SetValue(VisibilityBindingProperty, value); }
        }
        private static void OnVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomDataGridTemplateColumn)d).Visibility = (Visibility)e.NewValue;
        }
    }
