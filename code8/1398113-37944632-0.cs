    if (aCount % aWeight == 0)
    {
        var weightRatio = ((double)aWeight/bWeight);
        var countRatio = ((double)aCount / bCount);
        if (bCount % bWeight == 0 && bCount > 0 && (weightRatio == countRatio))
        {
            Console.WriteLine("Next is A! - pos 1");
            return;
        }
    
        Console.WriteLine("Next is B! - pos 2");
    }
    else if (bCount % bWeight == 0)
    {
        Console.WriteLine("Next is A! - pos 3");
    } 
