    struct Product
    {
       public int Id { get; set; }
       public string Name { get; set; }
    
       public Product(int id, string name)
       {
         this.Id=id;
         this.Name=name;
       }
       public void WriteInfo()
       {
          Console.WriteLine("Id: {0}, Id); 
          Console WriteLine("Name: {0}", Name)
       }
    
    }
    
     static void Main(string[] args)
        {
            var productList=new LinkedList<Product>;
            productList.AddLast(new Product(1,Apple));
            productList.AddLast(new Product(2,Banana));
      
            foreach(var product in productList)
            {
               product.WriteInfo()
            }
        }
