    csharp> List<int> prices= new List<int>(new int[] { 1, 2, 3, 4, 5 }); 
    csharp> prices.GetSumList(4);                                                              
    { 4 }
    csharp> prices.GetSumList(6); 
    { 2, 4 }
    csharp> prices.GetSumList(7); 
    { 3, 4 }
    csharp> prices.GetSumList(8); 
    { 3, 5 }
    csharp> prices.GetSumList(9); 
    { 4, 5 }
    csharp> prices.GetSumList(10);
    { 2, 3, 5 }
    csharp> prices.GetSumList(11); 
    { 2, 4, 5 }
    csharp> prices.GetSumList(12); 
    { 3, 4, 5 }
    csharp> prices.GetSumList(13); 
    { 1, 3, 4, 5 }
    csharp> prices.GetSumList(14); 
    { 2, 3, 4, 5 }
    csharp> prices.GetSumList(15); 
    { 1, 2, 3, 4, 5 }
    csharp> prices.GetSumList(16); 
    null
