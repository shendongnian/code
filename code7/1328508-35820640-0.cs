        var min = new DateTime(2016, 03, 03, 22, 0, 0);
        var max = (new DateTime(2016, 03, 03, 23, 0, 0));
        List<TestClassForMongo> searchResult = collection.Find( 
                    x => x.CreatedDateUtc > min &
                    x.CreatedDateUtc < max
                    ).ToList();
