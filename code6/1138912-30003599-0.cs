    public class Points
    {
        void Strings_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.WriteLine("Strings_CollectionChanged");
        }
        private ObservableCollection<string> strings = new ObservableCollection<string>();
        public ObservableCollection<string> Strings { get { return strings; } }
        public Points()
        {
            Strings.CollectionChanged += new NotifyCollectionChangedEventHandler(Strings_CollectionChanged);
            Strings.Add("new one");
            Strings.Add("new two");
            Strings.RemoveAt(0);
        }
    }
