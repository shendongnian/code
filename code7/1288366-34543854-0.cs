    public class VillageViewModel
    {
        public ObservableCollection<Village> VillageList { get; set; } 
    
        private Village selectedItem;
        public Village SelectedItem
        {
            get { return selectedItem; }
            set
            {
                if (selectedItem == value)
                    return;
                selectedItem = value;
                // Do logic on selection change.
            }
        }
    }
 
