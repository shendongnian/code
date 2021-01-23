    public class MyViewModel
    {
        private ObservableCollection<ParentModel> _myItems = new ObservableCollection<ParentModel>();
    
        public ObservableCollection<ParentModel> MyItems
        {
           get { return _myItems; }
        }
    
        public void AddParent(ParentModel parentModel)
        {        
            this.MyItems.Add(parentModel);
        }
    }
