    var filteredResults = 
       from res in Results
       where res.SeasonYear == 2013
       orderby res.resultDate
       group res by res.resultDate into dateGroup
       select new
       {
          ResultDate = dateGroup.Key,
          ResultList =
             from r in dateGroup
             where r.member.classifications.Single(c => c.year == 2013).Value != "U"
             group r by r.member.classifications.Single(c => c.year == 2013).Value into classifications
             orderby classifications
             select new
             {
                ClassificationGroup = classifications.Key,
                ClassificationList =                                     
                   from r2 in classifications.OrderByDescending(r => r.Value).Take(3)
                   select r2
             }          
       };
       
       filteredResults.ToList().ForEach(item => item.ResultList.ToList().ForEach(inner => inner.ClassificationList.ToList().ForEach(res => finalList.Add(res))));
