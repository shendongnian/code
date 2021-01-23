    public class InputDataService : BindableBase
    {
        private int _count;
        public string Name { get; set; }
        public int Count
        {
            get { return _count; }
            set { SetProperty(ref _count, value); }
        }
        public string Data { get; set;  }
        public void IpDataTrig(object sender,KeyEventArgs e)
        {
            var IpDataTb = new TextBox();
            IpDataTb = (TextBox)sender;
            if ((e.Key == Key.Enter) &&(!string.IsNullOrWhiteSpace(IpDataTb.Text)))
            {
                this.Data = IpDataTb.Text;
                ObsrCollTestVm.TestMe(this.Name, this.Data);
            }
        }
    }
