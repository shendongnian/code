    public class ObjectSelectionViewModel : ObjectViewModel
    {
        // The current list of selected items.
        public ObservableCollection<ObjectViewModel> SelectedItems { get; }
        public ObjectSelectionViewModel()
        {
            SelectedItems = new ObservableCollection<ObjectViewModel>();
            SelectedItems.CollectionChanged += (o, e) =>
            {
                 // Pseudo-code here
                 if (items were added)
                 {
                      // Subscribe each to PropertyChanged, using Item_PropertyChanged
                 }
                 if (items were removed)
                 {
                     // Unsubscribe each from PropertyChanged
                 }                   
            };
        }
        void Item_PropertyChanged(object sender, NotifyPropertyChangedArgs e)
        {
             // Notify that the local, group property (may have) changed.
             NotifyPropertyChanged(e.PropertyName);
        }
        public override string Name
        {
            get 
            {
                if (SelectedItems.Count == 0)
                {
                     return "[None]";
                }
                if (SelectedItems.IsSameValue(i => i.Name))
                {
                     return SelectedItems[0].Name;
                }
                return string.Empty;
            }
            set
            {
                if (SelectedItems.Count == 1)
                {
                    SelectedItems[0].Name = value;
                }
                // NotifyPropertyChanged for the traditional MVVM ViewModel pattern.
                NotifyPropertyChanged("Name");
            }           
        }
        public override string SelectionProfile
        {
            get 
            {
                if (SelectedItems.Count == 0)
                {
                     return "[None]";
                }
                if (SelectedItems.IsSameValue(i => i.SelectionProfile)) 
                {
                    return SelectedItems[0].SelectionProfile;
                }
                return "[Multi]";
            }
            set
            {
                foreach (var item in SelectedItems)
                {
                    item.SelectionProfile = value;
                }
                // NotifyPropertyChanged for the traditional MVVM ViewModel pattern.
                NotifyPropertyChanged("SelectionProfile");
            }           
        }
        ... etc ...
    }
    // Extension method for IEnumerable
    public static bool IsSameValue<T, U>(this IEnumerable<T> list, Func<T, U> selector) 
    {
        return list.Select(selector).Distinct().Count() == 1;
    }
