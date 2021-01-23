    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class Item
    {
        public int Id { get; set; }
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int CategoryId { get; set; }
    }
    public Category[] Categories
    {
        get
        {
            return new Category[]
            {
                new Category {Id=1, Name="Category One" },
                new Category {Id=2, Name="Category Two" },
                new Category {Id=3, Name="Category Three" },
            };
        }
    }
    public Item[] Items
    {
        get
        {
            return new Item[]
            {
                new Item { Id=1, CategoryId = 1, ItemName="Item 1", ItemPrice=10.00M},
                new Item { Id=2, CategoryId = 1, ItemName="Item 2", ItemPrice=10.00M},
                new Item { Id=3, CategoryId = 1, ItemName="Item 3", ItemPrice=10.00M},
                new Item { Id=4, CategoryId = 2, ItemName="Item 4", ItemPrice=10.00M},
                new Item { Id=5, CategoryId = 2, ItemName="Item 5", ItemPrice=10.00M},
                new Item { Id=6, CategoryId = 2, ItemName="Item 6", ItemPrice=10.00M},
                new Item { Id=7, CategoryId = 3, ItemName="Item 7", ItemPrice=10.00M},
                new Item { Id=8, CategoryId = 4, ItemName="Item 8", ItemPrice=10.00M},
            };
        }
    }
    void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CategoryRepeater.DataSource = Categories;
            CategoryRepeater.DataBind();
        }
    }
    protected void OnCategoryButtonClick(object sender, EventArgs e)
    {
        var button = sender as Button;
        var categoryId = Int32.Parse(button.CommandArgument);
        ItemRepeater.DataSource = Items.Where(i => i.CategoryId == categoryId);
        ItemRepeater.DataBind();
    }
