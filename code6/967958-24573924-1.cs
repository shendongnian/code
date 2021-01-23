    public partial class ConditionalControl : UserControl, INotifyPropertyChanged
    {
        public ConditionalControl()
        {
            InitializeComponent();
            this.IsReadOnly = false;
        }
        #region IsReadOnly
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public static readonly DependencyProperty IsReadOnlyProperty =
            DependencyProperty.Register("IsReadOnly", typeof(bool),
                typeof(ConditionalControl), new PropertyMetadata(new PropertyChangedCallback(OnReadOnlyChanged)));
        static void OnReadOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var visible = (bool)e.NewValue;
            var control = d as ConditionalControl;            
            if (visible)
            {
                control.TemplateTrueContent.Visibility = Visibility.Visible;
                control.TemplateFalseContent.Visibility = Visibility.Collapsed;
            }
            else
            {
                control.TemplateTrueContent.Visibility = Visibility.Collapsed;
                control.TemplateFalseContent.Visibility = Visibility.Visible;
            }
        }
        #endregion
        #region TemplateFalse
        public object TemplateFalse
        {
            get { return (object)GetValue(TemplateFalseProperty); }
            set { SetValue(TemplateFalseProperty, value); }
        }
        public static readonly DependencyProperty TemplateFalseProperty =
                DependencyProperty.Register("TemplateFalse", typeof(object),
                typeof(ConditionalControl), new PropertyMetadata(new PropertyChangedCallback(OnTemplateFalseChanged)));
        static void OnTemplateFalseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ConditionalControl;
            control.TemplateFalseContent.Visibility = !control.IsReadOnly ? Visibility.Visible : Visibility.Collapsed;
            control.OnPropertyChanged("TemplateFalse");
        }
        #endregion
        #region TemplateTrue
        public object TemplateTrue
        {
            get { return (object)GetValue(TemplateTrueProperty); }
            set { SetValue(TemplateTrueProperty, value); }
        }
        public static readonly DependencyProperty TemplateTrueProperty =
                DependencyProperty.Register("TemplateTrue", typeof(object),
                typeof(ConditionalControl), new PropertyMetadata(new PropertyChangedCallback(OnTemplateTrueChanged)));
        static void OnTemplateTrueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ConditionalControl;
            control.TemplateTrueContent.Visibility = control.IsReadOnly ? Visibility.Visible : Visibility.Collapsed;
            control.OnPropertyChanged("TemplateTrue");
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (propertyName == "TemplateFalse")
            {
                this.TemplateFalseContent.Content = this.TemplateFalse;
            }
            if (propertyName == "TemplateTrue")
            {
                this.TemplateTrueContent.Content = this.TemplateTrue;
            }
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
