        private void Page_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ApplicationView.GetForCurrentView().Orientation ==
            ApplicationViewOrientation.Landscape)
            {
                App.IsLandscape = (ApplicationView.GetForCurrentView()
                .VisibleBounds.Width < 600) ? false : true;
            }
            else
            {
                App.IsLandscape = false;
            }
        }
