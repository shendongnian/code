    public class MyUserControl : UserControl
    {
        public event ListChangedEventHandler OnChange;
    
        private void _bsMyBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        {
            // if no listeners, OnChange will be null, so need to check
            if(this.OnChange != null)
            {
                this.OnChange(this, e);
            }
        }
    }
