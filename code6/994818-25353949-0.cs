    public class Article{
        private ICollection<Category> _CategoryList;
        public int ArticleId { get; set;}
        public virtual ICollection<Category> CategoryList {
            get { return _CategoryList = _CategoryList?? new HashSet<Category>(); }
            set { _CategoryList= value; }
        }
    }
    public class Category{
        public int Id { get; set;}
        public string Caption { get; set;}
        public Article Article { get; set;}
    }
