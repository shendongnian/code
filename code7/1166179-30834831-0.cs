        private void SetText(int value)
        {
            this.points.Text = value.ToString();
            if (value >= 22)
            {
                hole10img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole11img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole12img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole13img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole14img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole15img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole16img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole17img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                hole18img.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
            }
        }
