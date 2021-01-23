    TotalCost = 0;
    double Area = Convert.ToDouble(SurfAreaTxt.Text);
    if (WoodTxt.Text.ToLower() == mahogany)
    {
        TotalCost += 150;
        if (Area > 750)
            TotalCost += 50;
        Console.Write(TotalCost);
    }
