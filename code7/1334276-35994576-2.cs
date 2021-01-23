    public class ContentBlockList : ObservableCollection<int>
        {
            ContentBlockList()
            {
                this.CollectionChanged += ContentBlockList_CollectionChanged;
            }
    
            void ContentBlockList_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
            {
    
            }
        }
