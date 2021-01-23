    class Test
    {
        public List<List<int>> Items { get; set; }
        public IEnumerable ItemsSource { get { return this.Items; } }
        public List<object> Flatten
        {
            get { return this.ItemsSource.Cast<IEnumerable>().SelectMany(sublist => sublist.Cast<object>()).ToList(); }
        }
    }
    static class Program
    {
        static void Main()
        {
            var t = new Test();
            t.Items = new List<List<int>>
            {
                new List<int> { 1, 2 },
                new List<int> { 11, 12 }
            };
            var r = t.Flatten;
        }
    }
