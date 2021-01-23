    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Source { get; set; }
        public CategoryEnum Category { get; set; }
        public string Instructions { get; set; }
        public virtual ICollection<RecipeNote> Notes { get; set; }
    }
