    public class ContentBlockList : ObservableCollection<int>
    {
        private bool internallyUpdating;
        public void SomeMethod()
        {
            this.internallyUpdating = true;
            // Do Stuff (Add to base collection)
            this.internallyUpdating = false;
            this.OnPropertyChanged(new PropertyChangedEventArgs(@"Count");
            this.OnPropertyChanged(new PropertyChangedEventArgs(@"Item[]");
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if(this.internallyUpdating)
            {
                return;
            }
            base.OnCollectionChanged(e);
        }
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if(this.internallyUpdating)
            {
                return;
            } 
            base.OnPropertyChanged(e);
        }
    }
