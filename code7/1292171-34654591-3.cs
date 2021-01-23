        private ObservableCollection<MultipleSelection> listBoxItems = new ObservableCollection<MultipleSelection>();
                public ObservableCollection<MultipleSelection> ListBoxItems
                {
                    get
                    {
                        return listBoxItems;
                    }
                    set
                    {
                        listBoxItems = value;
                        this.RaisePropertyChanged("ListBoxItems");
                    }
                }
        
                private MultipleSelection selectedListItem;
                public MultipleSelection SelectedListItem
                {
                    get
                    {
                        return selectedListItem;
                    }
                    set
                    {
                  selectedListItem = value;
                var selectedItems = ListBoxItems.Where(x => x.IsSelected);
                this.RaisePropertyChanged("SelectedListItem");
                     
                    }
                }
    
    public class MultipleSelection : INotifyPropertyChanged
            {
                private string item;
    
                public string Item
                {
                    get { return item; }
                    set
                    {
                        item = value;
                        this.RaisePropertyChanged("Item");
                    }
                }
    
                private bool isSelected;
    
                public bool IsSelected
                {
                    get { return isSelected; }
                    set
                    {
                        isSelected = value;
                        this.RaisePropertyChanged("IsSelected");
                    }
                }
            }
