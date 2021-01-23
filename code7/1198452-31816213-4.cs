    public class MainVM
    {
    
        public ObservableCollection<CategoryItem> Categories { get; set; }
    
        public MainVM()
        {
            Categories = new ObservableCollection<CategoryItem>();
        }
    
    }
    
    public class CategoryItem
    {
        public string Name { get; set; }
    }
