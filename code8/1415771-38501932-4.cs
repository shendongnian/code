    public class NotificationCollection<T> : ObservableCollection<T>
        where T : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler ItemPropertyChanged;
        
        protected virtual void OnItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            ItemPropertyChanged?.Invoke(sender, e);
        }
        
        protected override void ClearItems()
        {
            foreach (var item in Items)
            {
                DisconnectItem(item);
            }
            base.ClearItems();
        }
    
        protected override void InsertItem(int index, T item)
        {
            base.InsertItem(index, item);
            ConnectItem(item);
        }
    
        protected override void RemoveItem(int index)
        {
            DisconnectItem(Items[index]);
            base.RemoveItem(index);
        }
    
        protected override void SetItem(int index, T item)
        {
            DisconnectItem(Items[index]);
            base.SetItem(index, item);
            ConnectItem(item);
        }
        
        private void ConnectItem(T item)
        {
            if (item != null)
            {
                item.PropertyChanged += OnItemPropertyChanged;
            }
        }
        
        private void DisconnectItem(T item)
        {
            if (item != null)
            {
                item.PropertyChanged -= OnItemPropertyChanged;
            }
        }
    }
