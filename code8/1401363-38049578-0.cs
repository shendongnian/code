    var queryImageNames =
        from image in array // <-- Array is your name for the datasource
        group image by image.Path into newGroup
        orderby newGroup.Key
        select newGroup;
    foreach (var ImageGroup in queryImageNames)
    {
        Console.WriteLine("Key: {0}", nameGroup.Key);
        foreach (var image in ImageGroup )
        {
            Console.WriteLine("\t{0}, {1}", image.Source, image.Information);
        }
    }
