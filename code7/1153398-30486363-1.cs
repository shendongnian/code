    public class FruitBasket : ExtendedObservableCollection<IFruit>
    {
        protected override void ItemPropertyChanged(object sender, PropertyChangedEventArgs e){
            UpdateWeight();
            OnPropertyChanged("TotalWeight")
        }
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            UpdateWeight();
            OnPropertyChanged("TotalWeight")
            base.OnCollectionChanged(e);
        }
    }
