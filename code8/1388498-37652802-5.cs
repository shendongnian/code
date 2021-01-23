    var itemConsumed = FinalCons
                       .GroupBy(x => new { 
                                   x.PersonalID, 
                                   x.ItemID 
                       }) //group by both PersonalID and ItemID
                       .Select(x => new 
                       { 
                           PersonalID= x.Key.PersonalID, 
                           ItemID = x.Key.ItemID,
                           Consumption = x.Sum(a => a.Consumption)
                       })
                       .OrderBy(x => x.PersonalID).ThenBy(y=>y.ItemID);
                         //order by Personal ID and then by Item ID
