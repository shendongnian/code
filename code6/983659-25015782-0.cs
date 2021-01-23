    internal class Program
    {
        private static ObservableCollection<IItem> oc;
        private static void Main(string[] args)
        {
            oc = new ObservableCollection<IItem>();
            oc.CollectionChanged += oc_CollectionChanged;
            oc.Add(new IItem {Amount = 100});
            oc.Add(new IItem {Amount = 200});
            oc.Add(new IItem {Amount = 300});
            oc.RemoveAt(1);
        }
        private static void oc_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("{0} {1}", e.Action, oc.Sum(s1 => s1.Amount));
        }
    }
    internal class IItem
    {
        public int Amount { get; set; }
    }
