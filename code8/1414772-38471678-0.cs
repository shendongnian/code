    public class Item
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }
    public class Recipe
    {
        public int ProductID { get; set; }
        public List<Material> Materials { get; set; }
    }
    public class Material
    {
        public int ItemID { get; set; }
        public int Count { get; set; }
    }
