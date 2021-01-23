    public class ProductEditViewModel : Product
    {
      public int SelectedCategory { get; set; } // if this is not already a property of class Product
      public IEnumerable<Category> Categories { get; set; } // not a SelectList
      ....
    }
