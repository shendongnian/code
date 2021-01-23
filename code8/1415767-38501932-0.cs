    class ViewModel
    {
        public ViewModel()
        {
            Items = new NotificationCollection<Item>();
            Items.ItemPropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(Item.IsVisible))
                    OnPropertyChanged(nameof(IsVisible));
            };
        }
        
        public NotificationCollection<Item> Items { get; }
        
        public bool IsVisible => Items.All(i => i.IsVisible);
    }
