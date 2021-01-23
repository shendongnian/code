    var seed = new { 
        Result = new List<myItem>(), 
        Item1 = ( myItem )null, 
        Item2 = ( myItem )null 
    };
    // seed contains intermediate result and other items related to currentItem
    // [Item1, Item2, currentItem]
    // For the first item, it would be
    // [null, null, Id = 1]
    // For the second item, it would be
    // [null, Id = 1, Id = 2]
    // And the third
    // [Id = 1, Id = 2, Id = 3]
    // For nth item, it's
    // [Id = n-2, Id = n-1, Id = n]
    var final = input.Aggregate( seed, ( pr, i ) =>
    {
        if ( pr.Item1 != null )
        {
            var item1 = pr.Item1;
            item1.Sum3 = item1.Sum2 + i.Value;
        }
        if ( pr.Item2 != null )
        {
            var item2 = pr.Item2;
            item2.Sum2 = item2.Sum1 + i.Value;
        }
        pr.Result.Add( i );
        i.Sum1 = i.Value;
        // It will create lots of short life object.
        // If performance is bad, create named class just as this anonymous class,
        // update its properties and return it
        // pr.Item1 = pr.Item2;
        // pr.Item2 = pr.i;
        // return pr;
        return new { Result = pr.Result, Item1 = pr.Item2, Item2 = i };
    } );
