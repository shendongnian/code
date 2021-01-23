    if (Directory.Exists("SA_Data") && File.Exists("SA_Data/stock_names.txt"))
    {
        var stocks = new List<string>();
    
        foreach (string stock in File.ReadAllLines("SA_Data/stock_names.txt"))
        {
            MessageBox.Show(stock);
            stocks.Add(stock);
        }
        Global.stocks = stocks.ToArray();
    }
