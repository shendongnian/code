        string[] arr = new string[] { "3D", "Photoshop", "Java", "Design" };
        predicate = predicate.And(x => arr.Contains(x.Tags));
        var arr2 = new[] { "2", "4", "5", "21" };
        var predicateCatid = PredicateBuilder.False<Member>();
        foreach (var cat in arr2)
        {
            predicateCatid = predicateCatid.Or(x => (x.Catid + ",").Contains(cat + ","));               
        }
        predicate = predicate.And(predicateCatid);
