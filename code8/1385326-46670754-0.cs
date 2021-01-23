        private Windows.UI.Xaml.Controls.Frame frame;
        private Windows.UI.Xaml.Controls.Page page;
        private Ribo.Smart.App.UserControls.Components.Common.Toast toast;
        private DispatcherTimer timer = new DispatcherTimer();
        void timer_Tick(object sender, object e)
        {
            if (toast != null)
                ((Panel)page.FindName("layoutRoot")).Children.Remove(toast);
            toast = null;
            timer.Stop();
            timer.Tick -= timer_Tick;
        }
        private void Frame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
        {
            if (toast != null)
            {
                object layoutRoot = page.FindName("layoutRoot");
                if (layoutRoot != null)
                {
                    ((Panel)layoutRoot).Children.Remove(toast);
                    page = (Windows.UI.Xaml.Controls.Page)e.Content;
                    layoutRoot = page.FindName("layoutRoot");
                    ((Panel)layoutRoot).VerticalAlignment = VerticalAlignment.Stretch;
                    ((Panel)layoutRoot).Children.Add(toast);
                    if (layoutRoot is Grid)
                    {
                        toast.SetValue(Grid.RowSpanProperty, 100);
                    }
                }
            }
        }
        public void ShowMessage(string message)
        {
            frame = (Windows.UI.Xaml.Controls.Frame)Windows.UI.Xaml.Window.Current.Content;
            page = (Windows.UI.Xaml.Controls.Page)frame.Content;
            frame.Navigated -= Frame_Navigated;
            frame.Navigated += Frame_Navigated;
            toast = new Ribo.Smart.App.UserControls.Components.Common.Toast();
            toast.Message = message;
            toast.VerticalAlignment = Windows.UI.Xaml.VerticalAlignment.Bottom;
            toast.HorizontalAlignment = Windows.UI.Xaml.HorizontalAlignment.Center;
            int seconds = message.Length / 30;
            if (seconds < 2)
                seconds = 2;
            timer.Interval = new TimeSpan(0, 0, seconds);
            timer.Start();
            timer.Tick -= timer_Tick;
            timer.Tick += timer_Tick;
            object layoutRoot = page.FindName("layoutRoot");
            if (layoutRoot != null)
            {
                if (layoutRoot is Grid)
                {
                    toast.SetValue(Grid.RowSpanProperty, 100);
                }
                ((Panel)layoutRoot).Children.Add(toast);
            }
        }
