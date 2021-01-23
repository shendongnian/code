    public class CategoryModel
    {
        public IEnumerable<Category> Section1Categories{ get; set; }
        public IEnumerable<Category> Section2Categories{ get; set; }
    
        public class Category
        {
            public int Id { get; set; }
            public string Name { get; set; }
        } // end class category
    } // end class CategoryModel
