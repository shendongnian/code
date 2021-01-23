    // Make your own control deriving from TabControl
    class CustomTabControl : TabControl
    {
        // Subscribe to the Selecting event
        public CustomTabControl()
        {
            Selecting += tabSelecting;
        }
        private void tabSelecting(object sender, TabControlCancelEventArgs e)
        {
            // You would put your own logic here to detect which tabs to disable
            // For this example I'm disabling access to tab in index 1
            if (e.TabPageIndex == 1)
            {
                e.Cancel = true;
            }
        }
    }
