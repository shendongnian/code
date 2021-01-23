    public class ObjectSelectionViewModel : ObjectViewModel
    {
        // The current list of selected items.
        public ObservableCollection<ObjectViewModel> SelectedItems { get; }
        public override string Name
        {
            get 
            {
                if (SelectedItems.Count == 0)
                {
                     return "[None]";
                }
                if (SelectedItems.Count == 1) 
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
                if (SelectedItems.Count == 1) 
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
