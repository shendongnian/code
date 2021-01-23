    public class Category {
            private ObservableCollection<Category> _subCats = new ObservableCollection<Category>();
            public string Name { get; set; }
    
            public ObservableCollection<Category> SubCategories => this._subCats;
        }
