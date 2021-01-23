    void Rules_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
            {
                foreach (var v in e.NewItems)
                    ((IViewModelUIRule)v).ValidationDone += ViewModel_ValidationDone;
            }
 
    void ViewModel_ValidationDone(object sender, ViewModelUIValidationEventArgs e)
            {
                HasErrors = e.IsValid;
            }
