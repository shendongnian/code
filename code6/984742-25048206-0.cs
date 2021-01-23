    public enum Categorys
    {
        Acceleration,
        Area,
        Energy,
        Frequency,
        Length,
        Mass,
        Time,
        Velocity,
        Volume
    }
    private static readonly string[] DisplayNames = new string[]
    {
        "Acceleration",
        "Area",
        "Energy",
        "Frequency",
        "Length",
        "Mass",
        "Time",
        "Speed",
        "Volume"
    };
    private class CategoryItem
    {
        private Categorys Category;
        private string DisplayName;
        public CategoryItem(Categorys category, string display_name)
        {
            Category = category;
            DisplayName = display_name;
        }
        public override string ToString()
        {
            return DisplayName;
        }
        public static implicit operator Categorys(CategoryItem item)
        {
            return item.Category;
        }
    }
    
    private void Form1_Load(object sender, EventArgs e)
    {
        List<CategoryItem> items = new List<CategoryItem>();
        int i = 0;
        foreach (var category in Enum.GetValues(typeof(Categorys)))
            items.Add(new CategoryItem((Categorys)category, DisplayNames[i++]));
        CbCategory.DataSource = items;
    }
