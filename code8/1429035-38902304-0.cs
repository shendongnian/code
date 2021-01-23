    var seed = new { 
        Result = new List<myItem>(), 
        Item1 = ( myItem )null, 
        Item2 = ( myItem )null 
    };
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
        return new { Result = pr.Result, Item1 = pr.Item2, Item2 = i };
    } );
    foreach ( var item in final.Result )
    {
        Console.WriteLine( $"{item.ID} {item.Value} {item.Sum1} {item.Sum2} {item.Sum3}" );
    }
