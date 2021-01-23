    public class PerfectScrollListView : ListView
    {
        public PerfectScrollListView()
        {
            this.SizeChanged += PerfectScrollListView_SizeChanged;
        }
        private void PerfectScrollListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (ItemsPanelRoot != null)
            {
                ItemsPanelRoot.Width = e.NewSize.Width;
            }
        }
    }
