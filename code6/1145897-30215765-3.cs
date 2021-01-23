    public class Product
    {
        public Product()
        {
            Category = Category.Unassigned;
            // other stuff
        }
        // other stuff.
        public void AssignCategory(Category category) 
        {
            // Any associated logic.
            Category = category;
        }
        public Category Category { get; private set; } 
    }
