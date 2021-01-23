    public class Article
    {
       public Article(Product source)
       {
          this.ArticleNumber = source.ProductNumber;
          this.ArticleColor = source.ProductColor;
       }
    }
    public class Customer_
    {
        public Customer_(Customer source) 
        {
            this.FirstName = source.FirstName;
            this.LastName = source.LastName;
            this.Article = source.Product.Select(o => new Article(o)).ToList()
        }
        ...
    }
    //and finally to convert the list you can do something like
    //initial list
    var Cus = new List<Customer>() { ... etc. }
    
    /converted list
    var Cus_ = Cus.Select(o => new Cusomter_(o)).ToList();
