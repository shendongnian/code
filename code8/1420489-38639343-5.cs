    var matchingHouseList = housesAndResidents.ToList(); 
    // you don't need the list, you can use foreach directly,
    // but whenever you access housesAndResidents you will execute that query
    // ToList materializes this query into a collection, so you can enumerate it or use the Count property
    foreach(var x in matchingHouseList )
    {
        Console.WriteLine("House:{0} Matching-Resident(s):{1}"
            , x.house.Name
            , String.Join(", ", x.matchingResidentList.Select(r => r.Name)));
    }
