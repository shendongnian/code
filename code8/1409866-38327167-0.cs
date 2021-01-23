    public class Food
    {
        protected Text Qty;
        protected Text Price;
        protected Text Have;
    
        public void setQty(Text Qty)
        {
            this.Qty = Qty;
        }
    
        public void setPrice(Text Price)
        {
            this.Price = Price;
        }
    
        public void setHave(Text Have)
        {
            this.Have = Have;
        }
    
        public Text getQty()
        {
            return this.Qty;
        }
    
        public Text getPrice()
        {
            return this.Price;
        }
    
        public Text getHave()
        {
            return this.Have;
        }
    }
