        // two lists are for assigning ItemsSource and
        // other is for all items to represent.
        List<string> lstInt = new List<string>();
        List<string> lstIntFull = new List<string>();
        void BlankPage3_Loaded(object sender, RoutedEventArgs e)
        {
            // below code will get ScrollViewer from ListBox and define the event handler to it's ViewChanged event.
            sv = VisualTreeHelper.GetChild((VisualTreeHelper.GetChild(lbx, 0) as Border), 0) as ScrollViewer;
            sv.ViewChanged += sv_ViewChanged;
            for (int i = 0; i < 100; i++)
            {
                lstIntFull.Add(i.ToString());
            }
            for (int i = 0; i <= 10; i++)
            {
                lstInt.Add(lstIntFull[i]);
            }
            lbx.ItemsSource = lstInt;
        }
        // event handler of ViewChanged event that we declared on PageLoad
        void sv_ViewChanged(object sender, ScrollViewerViewChangedEventArgs e)
        {
            var verticalOffset = sv.VerticalOffset;
            var maxVerticalOffset = sv.ScrollableHeight; //sv.ExtentHeight - sv.ViewportHeight;
            if (maxVerticalOffset < 0 ||
                verticalOffset == maxVerticalOffset)
            {
                // Scrolled to bottom
                // So, write the code here to load next set of data
                var itemCount = (lbx.ItemsSource as List<string>).Count;
                for (int i = itemCount; i <= itemCount + 10; i++)
                {
                    if (i < 100)
                    {
                        lstInt.Add(lstIntFull[i]);
                    }
                }
                // await Task.Delay(2000);
                // lbx.ItemsSource = null;
                lbx.ItemsSource = lstInt;
            }
            else
            {
                // Not scrolled to bottom
                
            }
        }
