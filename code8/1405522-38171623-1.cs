    public class MyUserControl : UserControl
    {
        public event EventHandler OnChange;
    
        private void _bsMyBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            // if no listeners, OnChange will be null, so need to check
            if(this.OnChange != null)
            {
                this.OnChange(this, new EventArgs());
            }
        }
    }
