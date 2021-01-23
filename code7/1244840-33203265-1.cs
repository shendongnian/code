    public class MenuItem
    {
        public string Name { get; set; }
        public Uri ImageUri { get; set; }
    }
    public class CategoriesFactory
    {
        public static IDictionary<int, MenuItem> GetCategories()
        {
            var categories = new Dictionary<int, MenuItem>();
            categories.Add(1, new MenuItem() { Name = "Menu1", ImageUri = new Uri("Icons/image.png", UriKind.RelativeOrAbsolute) });
            //add more categories
            return categories;
        }
    }
