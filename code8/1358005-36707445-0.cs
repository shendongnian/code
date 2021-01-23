    namespace VendingMachine
    {
        public class Vend
        {
            private string[] VALID_ROWS = new string[] { "A", "B", "C", "D", "E", "F" };
            private string[] VALID_COLS = new string[] { "01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12" };
    
            public Vend()
            {
                ProductSlot = new Dictionary<string, Dictionary<string, Item>>();
                foreach(string row in VALID_ROWS)
                {
                    ProductSlot.Add(row, new Dictionary<string,Item>());
                    foreach(string col in VALID_COLS)
                        ProductSlot[row].Add(col, null);
                }
            }
    
            public void AddProduct(string row, string col, Item item)
            {
                if (!VALID_ROWS.Contains(row)) throw new ArgumentOutOfRangeException("row", string.Format("The row provided: `{0}` is not valid.", row));
                if (!VALID_COLS.Contains(col)) throw new ArgumentOutOfRangeException("col", string.Format("The column provided: `{0}` is not valid.", col));
                ProductSlot[row][col] = item;
            }
    
            public double GetPrice(string row, string col)
            {
                double price = GetProduct(row, col).Price;
                return price;
            }
    
            public string GetProductName(string row, string col)
            {
                string name = GetProduct(row, col).ProductName;
                return name;
            }
    
            public int GetQuantity(string row, string col)
            {
                int qty = GetProduct(row, col).Quantity;
                return qty;
            }
    
            public Item PurchaseItem(string row, string col)
            {
                Item item = GetProduct(row, col);
                if (item.Quantity < 1) throw new OutOfStockException("This item is out of stock, please select another item.");
                if (CreditMoney < item.Price) throw new InsufficientFundsException("There is not enough money to purchase this item.");
                item.Quantity--;
                CreditMoney -= item.Price;
                return item;
            }
    
            public string PrintProductList()
            {
                StringBuilder sb = new StringBuilder();
                foreach (string row in VALID_ROWS)
                {
                    foreach (string col in VALID_COLS)
                    {
                        Item item = GetProduct(row, col);
                        if (item == null) continue;
                        sb.AppendLine(string.Format("\t{0} : {1} @ {2} ea.\t{3}", string.Concat(row, col), item.Quantity.ToString(), item.Price.ToString("C2"), item.ProductName));
                    }
                }
                return sb.ToString();
            }
    
            public Item GetProduct(string row, string col)
            {
                if (!VALID_ROWS.Contains(row)) throw new ArgumentOutOfRangeException("row", string.Format("The row provided: `{0}` is not valid.", row));
                if (!VALID_COLS.Contains(col)) throw new ArgumentOutOfRangeException("col", string.Format("The column provided: `{0}` is not valid.", col));
                Item item = ProductSlot[row][col];
                return item;
            }
    
            double _creditMoney = 0.00;
            public double CreditMoney
            {
                get { return _creditMoney; }
                set
                {
                    if (value < 0) throw new ArgumentOutOfRangeException("CreditMoney", "CreditMoney cannot be reduced to below $0.00.");
                    _creditMoney = value;
                }
            }
            public Dictionary<string, Dictionary<string, Item>> ProductSlot { get; set; }
    
            public class Item
            {
                public Item() { }
                public Item(string name, double price, int qty)
                {
                    ProductName = name;
                    Price = price;
                    Quantity = qty;
                }
                private int _quantity = 0;
                public int Quantity 
                {
                    get { return _quantity; }
                    set
                    {
                        if (value < 0) throw new ArgumentOutOfRangeException("Quantity", "Quantity cannot be less than zero.");
                        _quantity = value;
                    }
                }
                public string ProductName { get; set; }
                public double Price { get; set; }
            }
    
            public class InsufficientFundsException : Exception
            {
                public InsufficientFundsException() { }
                public InsufficientFundsException(string message)
                    : base(message) { }
                public InsufficientFundsException(string message, Exception innerException)
                    : base(message, innerException) { }
    
            }
    
            public class OutOfStockException : Exception
            {
                public OutOfStockException() { }
                public OutOfStockException(string message)
                    : base(message) { }
                public OutOfStockException(string message, Exception innerException)
                    : base(message, innerException) { }
    
            }
        }
    }
