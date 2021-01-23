    public class RecipeLine
    {
        [Key]
        public int RecipeLineId { get; set; }
        public int RecipeId { get; set; }
        public double Quantity { get; set; }
        public virtual UnitOfMeasureModel UnitOfMeasure { get; set; }
        public virtual IngredientModel Ingredient { get; set; }
        public string QuantityUomIngredient => $"{Quantity} {UnitOfMeasure?.Abbreviation ?? ""} {Ingredient?.Name ?? ""}";
    }
