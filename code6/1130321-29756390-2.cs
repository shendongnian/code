    public class Movie
        {
            public int ID { get; set; }
            public string Title { get; set; }
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public decimal Price { get; set; }
          
            //New Property to Store Image
            public byte[] Image { get;set;}
    
            //Feel free to move this out of your entities
            [NotMapped]
            public HttpPostedFileBase Content { get;set;}
            public class MovieDBContext : DbContext
            {
                public DbSet<Movie> Movies { get; set; }
            }
        }
