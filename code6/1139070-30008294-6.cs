    public class MenuListViewModel : BaseViewModelCollection<Menu>
    {
       public MenuListViewModel()
       {
          var data = new List<Menu> { some data ... }; // your real list of menus
          // initialize the collection view
          FilteredItems = CollectionViewSource.GetDefaultView(data);
          // apply filtering delegate
          FilteredItems.Filter = i =>
          {
             // This will be invoked for every item in the underlying collection 
             // every time Refresh is invoked
             if (string.IsNullOrEmpty(FilterString)) return true;
             Menu m = i as Menu;
             return m.Time.ToString().StartsWith(FilterString);
          };
       }
       private string filterString;
       public string FilterString
       {
           get { return filterString; }
           set
           {
               if (Equals(value, filterString)) return;
               filterString = value;
               FilteredItems.Refresh(); // tirggers filtering logic
               RaisePropertyChanged("FilterString"); 
           }
       }
        public ICollectionView FilteredItems { get; set; }
    }
