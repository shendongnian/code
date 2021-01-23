        public class BundleGroup : ObservableCollection<BundleData>
    {
        public BundleGroup(IEnumerable<BundleData> items) : base(items)
        {
        }
        public string idfile { get; set; }
        public string judul { get; set; }
        //  etc.
    }
