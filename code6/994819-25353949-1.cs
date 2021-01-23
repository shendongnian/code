    public class Article{
        public int ArticleId { get; set;}
        public Category Category { get; set;}
    }
    public class Category{
        private ICollection<Article> _ArticleList;
        public int Id { get; set;}
        public string Caption { get; set;}
        public virtual ICollection<Article> ArticleList {
            get { return _ArticleList= _ArticleList?? new HashSet<Article>(); }
            set { _ArticleList= value; }
        }
    }
