     double resultvalue = 0;
        Slider slid = new Slider();
        public MainPage()
        {
            InitializeComponent();      
            slid.LargeChange = 2.0;
            slid.SmallChange = 0.0;
            LayoutRoot.Children.Add(slid);
           slid.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sldr_ValueChanged);
           
        }
        void sldr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
             double newValue = Math.Round(e.NewValue);
            resultvalue += 2;
            txtBox1.Text = resultvalue.ToString();
            slid.Value = resultvalue;
        }
