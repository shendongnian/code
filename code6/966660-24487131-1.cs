       {
            Slider slid = new Slider();
            LayoutRoot.Children.Add(slid);
            slid.ValueChanged += new RoutedPropertyChangedEventHandler<double>(sldr_ValueChanged);
        }
        void sldr_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double resultvalue = 0;
            double newValue = Math.Round(e.NewValue);           
            //add 2
        }
