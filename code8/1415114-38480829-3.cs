    public class ReceiptBuilder
    {
        private Receipt r;
        
        public ReceiptBuilder()
        {
            r = new Receipt();
        }
        
        public ReceiptBuilder WithName(string name)
        {
            r.Name = name;
            return this;
        }
        
        public ReceiptBuilder WithDate(DateTime dt)
        {
            r.Date = dt;
            return this;
        }
        
        public ReceiptBuilder WithItem(string text, Action<ReceiptItemBuilder> itemBuilder)
        {
            var rib = new ReceiptItemBuilder(text);
            itemBuilder(rib);
            r.AddItem(rib.Build());
            return this;
        }
        
        public Receipt Build()
        {
            return r;
        }
    }
                                       
    public class ReceiptItemBuilder
    {
        private ReceiptItem ri;
        
        public ReceiptItemBuilder(string text)
        {
            ri = new ReceiptItem(text);
        }
        
        public ReceiptItemBuilder WithIngredients(string ings)
        {
            ri.Ingredients = ings;
            return this;
        }
        // WithType omitted for brevity. 
        internal ReceiptItem Build()
        {
            return ri;
        }
    }
