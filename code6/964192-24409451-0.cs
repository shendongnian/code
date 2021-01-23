       public class ThatSpecificViewModel
    {
        public ThatSpecificViewModel(int id, string categoryName, string subCategoryName) 
        {
            this.ID = id;
            this.CategoryName = categoryName;
            this.SubCategoryName = subCategoryName;
        }
        
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
    }
