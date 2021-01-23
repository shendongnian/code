    namespace <NewNamespaceforDTO> //Ws.Models 
    {
        public class samplemodelDTO
        {            
            public int id { set; get; }    
            public string Productname { get; set; }  
            public int Productquantity { get; set; }   
            public string ProductReview { get; set; }    
        }
    }
    public List<samplemodelDTO> Getproducts()
    {
         var query = from t in db.products.AsEnumerable()
                     join p in db.ratings.AsEnumerable() on t.product_id equals p.prod_id
                     select new samplemodelDTO()
                     {
                          Productname=t.product_name,
                          Productquantity=t.quantity,
                          ProductReview=p.rating1
                     };
          return query.ToList();
    }
