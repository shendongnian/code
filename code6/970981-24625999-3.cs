        public ViewModel()
        {
            IEnumerable<int> originalData = Enumerable.Range(1, 12);
            Items = new CompositeCollection();
            Items.Add(new CollectionContainer() { Collection = originalData.Take(originalData.Count() > 8 ? 7 : 8) });
            if (originalData.Count() > 8)
                Items.Add(originalData.Count() - 7 + " more");
        }
        public CompositeCollection Items { get; set; }
