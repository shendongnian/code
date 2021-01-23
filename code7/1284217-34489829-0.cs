    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual Category Category { get; set; }
        public int CategoryID { get; set; }
    }
    
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Category> Categories { get; set; }
    
        public virtual Category Parent { get; set; }
        public int? ParentID { get; set; }
    
        private List<int> GetIds(Category category)
        {            
            var list = Products == null ? new List<int>() : Products.Select(x => x.id).ToList();
            if (Categories != null)
                Categories.ToList().ForEach(x => {
                    list.Add(x.id);
                    list.AddRange(x.GetIds(x));
                }
            );            
            return list;
        }
    
        public List<int> GetIds()
        {
            return GetIds(this);
        }
    }
