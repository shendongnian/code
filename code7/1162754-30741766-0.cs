        /// <summary>
        /// Handles application navigation
        /// Reports current View to analytics
        /// </summary>
        /// <param name="sender">Frame</param>
        /// <param name="e">NavigationEventArgs</param>
        private void FrameNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {            
            try
            {
                var viewName =
                    e.Uri.ToString().Replace("//", "/").Replace("/Views/", "").Split('.').First().Replace("View", "");
                AnalyticsHelper.TrackPageView(viewName);
            }
            catch (Exception ex)
            {
                AnalyticsHelper.TrackException("FrameNavigatedTelemetry", ex, e.Uri != null ? e.Uri.ToString() : "");
            }
        }
