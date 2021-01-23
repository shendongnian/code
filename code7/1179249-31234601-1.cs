    public class RegistryItem
    {
        public string Header { get; set; }
        public List<GuestItem> GuestList { get; set; }
        public RegistryItem ()
        {
            GuestList = new List<GuestItem>();
        }
    }
