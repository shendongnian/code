    using System.ComponentModel.DataAnnotations;
    namespace RecipeSite.Models
    {
        public class Recipe
        {
            [Key]
            public int Identifier { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
