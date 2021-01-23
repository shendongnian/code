    public class YourViewModel
    {
        private context=new YourContext();
        public YourViewModel()  
        {
          context.ItemProperties.Where(ip=>ip.ItemId==CurrentItem.Id).Load();
          ItemProperties=context.ItemProperties.Local;
        }
    
        private ObservableCollection<Property> _itemProperties;
    
        public ObservableCollection<Property> ItemProperties
        {
            get { return _itemProperties; }
            set
            {
               _itemProperties= value;
               OnPropertyChanged("ItemProperties");
            }
        }
        public void SaveItemProperties()
        {
          context.SaveChanges();
        }
    }
