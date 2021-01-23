     // Optional ToDo: pass a int value indicating which "column" to add up
        public decimal GetSubTotal()
        {
    
            decimal TotalValue = default(decimal);
            decimal tmp = default(decimal);
    
            // arrays and collections start at index(0) not (1)
          
    
            for (int n = 0; n <= ListView1.Items.Count - 1; n++)
            {
                // ToDo: Not all items must have the same number of SubItems
                // should also check SubItems Count >= 1 for each item
                // try to get the value:
                if (decimal.TryParse(ListView1.Items(n).SubItems(1).Text, tmp))
                {
                    TotalValue += tmp;
                }
            }
    
            return TotalValue;
        }
