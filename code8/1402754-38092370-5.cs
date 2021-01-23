    string decimalSeperator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;
    List<Data> results = new List<Data>();
    foreach(string line in File.ReadAllLines(path).Skip(1))
    {
        if (line == null)
            continue;
    
        int indexOfNextXY = 0;
        while (true)
        {
            int indexOfXY = line.IndexOf("16XY", indexOfNextXY) + "16XY".Length;
            int indexOfPlus = line.IndexOf("+", indexOfXY + 16) + "+".Length;
            indexOfNextXY = line.IndexOf("16XY", indexOfPlus);
    
            string xyValue = line.Substring(indexOfXY - 2, 18); // -2 to get the XY part
            string price = indexOfNextXY < 0 ? line.Substring(indexOfPlus) : line.Substring(indexOfPlus, indexOfNextXY - indexOfPlus);
    
            string intPart = price.Substring(0, price.Length - 2);
            string decimalPart = price.Substring(price.Length - 2);
            price = intPart  + decimalSeperator + decimalPart;
                        
                        
            results.Add(new Data (){ XYValue = xyValue, Price = Convert.ToDecimal(price) });
    
            if (indexOfNextXY < 0)
                break;
        }
    }
