    public class ItemVm
    {
        public int ItemId { get; set; }
        public string ItemUrl
        {
            get { return String.Format("http://stackoverflow.com/questions/{0}", ItemId); }
        }
    }
