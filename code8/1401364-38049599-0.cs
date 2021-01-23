    var pathPartitions = array.GroupBy(x => x.Path);
    
    foreach(var grp in pathPartitions)
    {
        Console.WriteLine(grp.Key);
        var orderedPartition = grp.OrderBy(x => x.Source);
        foreach(var x in orderedPartition )
            Console.WriteLine($"\"{x.Source}\":   \"{x.Information}\"");
    }
