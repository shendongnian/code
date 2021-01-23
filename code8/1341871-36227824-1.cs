    public static readonly DependencyProperty ModelProperty = DependencyProperty.Register("Model",
            typeof(Model), typeof(MainWindow));
        public Model Model
        {
            get { return (Model)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }
