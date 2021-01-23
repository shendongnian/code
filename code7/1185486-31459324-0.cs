    public static string GetCustomStringQuantity(double quantity)
        {
            string customQuantity ;
            quantity = Math.Round(quantity, 9 - ((int) Math.Log10(Math.Abs(quantity))+1),MidpointRounding.AwayFromZero);            
            customQuantity = quantity.ToString();  
            customQuantity= (quantity %1==0)?(customQuantity+".").PadRight(9, '0'):customQuantity.PadRight(9, '0');            
            if (customQuantity.Length > 9)
                customQuantity = customQuantity.Substring(0, 9);
            else if (customQuantity.Length == 9 && customQuantity.EndsWith("."))
                customQuantity = customQuantity.Substring(0, 8);
            return customQuantity; 
        }
