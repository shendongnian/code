        public ObservableCollection<MyDataItem> DataItems 
        {
            get
            {
                List<MyDataItem> items = new List<MyDataItem>(5);
                
                for (int i = 0; i < 5; i++)
                {
                    items.Add(new MyDataItem { abc = abc[i], qrt = qrt[i], xyz = xyz[i] });
                }
                var observable = new ObservableCollection<MyDataItem>(items);
                var view = CollectionViewSource.GetDefaultView(observable) as IEditableCollectionView;
                view.NewItemPlaceholderPosition = NewItemPlaceholderPosition.AtEnd;
                return observable;
            }
        }
       
