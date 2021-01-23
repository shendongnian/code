       {
            Slider slid = new Slider();
            slid.LargeChange = 2.0;
            slid.SmallChange = 0.0;
            LayoutRoot.Children.Add(slid);
            slid.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sldr_ValueChanged);
        }
        void sldr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double resultvalue = 0;
            double newValue = Math.Round(e.NewValue);           
          
        }
