    private void MainPage_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (e.PreviousSize != e.NewSize)
            {
                if (MainPage.ActualWidth > 1024)
                {
                    SpecialtyGridView.ItemTemplate = Resources["DesktopTemplate"] as DataTemplate;
                }
                else
                {
                    SpecialtyGridView.ItemTemplate = Resources["LaptopTemplate"] as DataTemplate;
                }
            }
        }
      
