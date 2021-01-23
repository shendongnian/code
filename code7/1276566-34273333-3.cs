    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (PhoneApplicationService.Current.State.ContainsKey("showImage"))
        {
            var showImage = PhoneApplicationService.Current.State["showImage"] as Dictionary<int, bool>;
            if (showImage != null)
            {
                foreach (var key in showImage.Keys)
                {
                    if (_images.ContainsKey(key))
                    {
                        if (showImage[key])
                        {
                            _images[key].Visibility = System.Windows.Visibility.Visible;
                        }
                        else
                        {
                            _images[key].Visibility = System.Windows.Visibility.Collapsed;
                        }
                    }
                }
            }
        }
    }
