    internal class Program
    {
        private static ObservableCollection<IItem> oc = new ObservableCollection<IItem>();
        private static readonly long[] crossCheck = {1,2,3};
        private static void Main(string[] args)
        {
            oc.CollectionChanged += oc_CollectionChanged;
            oc.Add(new IItem {Id=1,Amount = 100});
            oc.Add(new IItem {Id=2,Amount = 200});
            oc.Add(new IItem {Id=3,Amount = 300});
            oc.RemoveAt(1);
        }
        private static void oc_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("{0} {1}", e.Action, oc.Sum(s1 => s1.Amount));
            if (crossCheck.SequenceEqual(oc.Select(s1 => s1.Id).Intersect(crossCheck)))
                Console.WriteLine("I have all elements I wanted!");
            if (e.OldItems != null && e.Action.Equals(NotifyCollectionChangedAction.Remove) &&
                e.OldItems.Cast<IItem>().Any(a1 => a1.Id.Equals(2))) Console.WriteLine("I've lost item two");
        }
    }
    internal class IItem
    {
        public long Id { get; set; }
        public int Amount { get; set; }
    }
