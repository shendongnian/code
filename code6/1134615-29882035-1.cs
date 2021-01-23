        public int TotalPay
        {
            get
            {
                int qty;
                int price;
                
                if (int.TryParse(Quantity, out qty) && int.TryParse(UnitPrice, out price))
                {
                    return qty * price;
                }
                return 0;
            }
        }
