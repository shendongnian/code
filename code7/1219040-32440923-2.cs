    if (e.NewSize.Width < 300)
    {
        cars.Items.ToList().GetRange(2, 2).ForEach(x => x.IsEnabled = false);
    }
    else //e.NewSize.Width >= 300
    {
        cars.Items.ToList().GetRange(2, 2).ForEach(x => x.IsEnabled = true);
    }
    
    
 
