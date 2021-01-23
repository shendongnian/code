    var passedDict = passed.ToDictionary(p => p.DataDate, p);
    var failedDict = failed.ToDictionary(p => p.DataDate, p);
    var startedOn = DateTime.....
    var endedOn = DateTime....
    var combined = Enumerable
      .Range(0, 1 + endedOn.Subtract(startedOn).Days)
      .Select(x => 
        {
          Pass pass;
          Fail fail;
          var result = new ReportData()
          result.DataDate = staredOn.AddDays(x),
          if (passedDict.TryGetValue(result.DataDate, out pass))
          {
            result.Quantity = pass.Quantity;
            result.CumulativeQuantity = pass.CumulativeQuantity;
          }
          if (failedDict.TryGetValue(result.DataDate, out fail))
          {
            result.Rejected= fail.Rejected;
            result.CumulativeRejected = fail.CumulativeRejected ;
          }
          return result;
        })
      .ToList();
          
      
