    public class RowModel {
         
        public RowModel() {
            Item = new TextBox();
            Product = new TextBox();
            Quantity = new TextBox();
        }
        public int Index { get; set; } // might be useful to display better error messages
        public TextBox Item { get; set; }
        public TextBox Product { get; set; }
        public TextBox Quantity { get; set; }
        // here we only check if this single row is valid
        public bool IsValid() {
            return !String.IsNullOrWhiteSpace(Item.Text) 
                && !String.IsNullOrWhiteSpace(Product.Text) 
                && !String.IsNullOrWhiteSpace(Quantity.Text);
            // any additional validation here, e.g. Quantity > 0
        }
    }
