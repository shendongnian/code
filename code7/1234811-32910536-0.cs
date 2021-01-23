        public static readonly DependencyProperty InputDTsProperty =
            DependencyProperty.Register("InputDTs", typeof(Windows.UI.Core.CoreInputDeviceTypes), typeof(MainPage), new PropertyMetadata(null, new PropertyChangedCallback(InputDTsPropertyChanged))); 
        public Windows.UI.Core.CoreInputDeviceTypes InputDTs
        {
            //get;
            //set;
        }
        private static void InputDTsPropertyChanged(DependencyObject source, DependencyPropertyChangedEventArgs e)
        {
            //set MyInkCanvas.InkPresenter.InputDeviceTypes here
        }
        public MainPage()
        {
            this.InitializeComponent();
            Binding inputBinding = new Binding();
            inputBinding.Source = DataModel.DeviceInput;
            inputBinding.Mode = BindingMode.OneWay;
            this.SetBinding(InputDTsProperty, inputBinding);
        }
