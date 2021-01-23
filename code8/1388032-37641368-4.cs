    private class TabsCollection : ObservableCollection<Tab>
    {
        public TabsCollection(TabGroup owner)
        {
            this.owner = owner;
        }
        private TabGroup owner;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e); //this will update the TabControl
            var newItems = e.NewItems?.Cast<Tab>()?.ToList();
            if (newItems?.Any() == true)
                owner.Selected = newItems.Last();
        }
    }
