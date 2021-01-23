        public event RoutedEventHandler TestClick;
        void onSearchFocus(object sender, RoutedEventArgs e)
        {
            if (this.TestClick != null)
            {
                this.TestClick(this, e);
            }
        }
