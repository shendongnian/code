	public class Recipe
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Category { get; set; }
		// ...
		
		public virtual ICollection<Recipe> Recipies { get; set; }
	}
	public class Ingredient
	{
		public int Id { get; set; }
        public string Name { get; set; }
		public decimal Amount { get; set; }
		public string Unit { get; set; }
		
		public virtual Recipe Recipe { get; set; }
		public int RecipeId { get; set; }
	}
