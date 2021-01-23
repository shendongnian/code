    enum MaterialType
    {
        None,
        Wood,
        Glass,
        Steel,
        Cloth
    }
    class Ingredient
    {
        public Ingredient(MaterialType type, int amount)
        {
            Type = type;
            Amount = amount;
        }
        public MaterialType Type { get; }
        public int Amount { get; }
    }
    class Recipe
    {
        public Recipe(string name, params Ingredient[] ingredients) 
            : this(name, (IEnumerable<Ingredient>) ingredients)
        {          
        }
        public Recipe(string name, IEnumerable<Ingredient> ingredients)
        {
            Name = name;
            Ingredients = ingredients.ToArray();
        }
        public string Name { get; }
        public Ingredient[] Ingredients { get; }
    }
    [TestClass]
    public class FindAllItemsFixture
    {
        private readonly static IEnumerable<Recipe> AllItemRecipes = new List<Recipe>
        {
            new Recipe("Sword", new Ingredient(MaterialType.Steel, 3)),
            new Recipe("Spear", new Ingredient(MaterialType.Steel, 1), new Ingredient(MaterialType.Wood, 3)),
            new Recipe("Table",  new Ingredient(MaterialType.Wood, 6)),
            new Recipe("Chair",  new Ingredient(MaterialType.Wood, 4)),
            new Recipe("Flag",  new Ingredient(MaterialType.Cloth, 2)),
        };
        IEnumerable<Recipe> GetAllRecipesUsingMaterial(MaterialType materialType)
        {
            return AllItemRecipes.Where(r => r.Ingredients.Any(i => i.Type == materialType));
        }
        [TestMethod]
        public void GetAllWoodenRecipes()
        {
            var expectedNames = new string[] { "Spear", "Table", "Chair" };
            var woodenItems = GetAllRecipesUsingMaterial(MaterialType.Wood);
            CollectionAssert.AreEqual(expectedNames, woodenItems.Select(i => i.Name).ToArray());
        }
        [TestMethod]
        public void GetAllClothRecipes()
        {
            var expectedNames = new string[] { "Flag" };
            var clothItems = GetAllRecipesUsingMaterial(MaterialType.Cloth);
            CollectionAssert.AreEqual(expectedNames, clothItems.Select(i => i.Name).ToArray());
        }
    }
