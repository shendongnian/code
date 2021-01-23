    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    
    namespace MvcMovie2.Models
    {
        public class Movie
        {
            public int ID { get; set; }
            public string Title { get; set; }
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime ReleaseDate { get; set; }
            public string Genre { get; set; }
            public string Rating { get; set; }
            public decimal Price { get; set; }
        }
    
        public class MovieDBContext : DbContext
        {
            public DbSet<Movie> Movies { get; set; }
        }
    }
