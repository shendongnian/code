    class Inventory
    {
        List<Product> items;
        int maxSize;
        public Inventory(int in_maxSize)
        {
            maxSize = in_maxSize;
            items = new List<Product>();
        }
        public bool AddProduct(Product in_Product)
        {
            if(items.Count < maxSize)
            {
                items.Add(in_Product);
                return true;
            }
            else
            {
                return false;
            }
        }
        public Product getProduct(int index)
        {
            return items[index];
        }
        
        public void removeProduct(int index)
        {
            items.removeAt(index);
        }
    }
