    List<Tuple<DateTime, DateTime>> dates = new List<Tuple<DateTime, DateTime>>
    	{
    		Tuple.Create(new DateTime(2015, 1,1), new DateTime(2015, 1,11)),
    		Tuple.Create(new DateTime(2015, 1,2), new DateTime(2015, 1,4)),
    		Tuple.Create(new DateTime(2015, 1,9), new DateTime(2015, 1,13)),
    		Tuple.Create(new DateTime(2015, 1,18), new DateTime(2015, 1,20))
    	};
    	
    	var availableDates = dates.Aggregate<Tuple<DateTime, DateTime>, IEnumerable<DateTime>, IEnumerable<DateTime>>(new List<DateTime>(),
                                               (allDates, nextRange) => allDates.Concat(Enumerable.Range(0, (nextRange.Item2 - nextRange.Item1).Days).Select(e => nextRange.Item1.AddDays(e))),
                                               allDates => allDates);
    								   
    								   
    	var numDays = availableDates.Aggregate<DateTime, Tuple<DateTime, int>, int>(Tuple.Create(DateTime.MinValue, 0),
                                                                             (acc, nextDate) =>
                                                                             {
                                                                                 int daysSoFar = acc.Item2;
    
                                                                                 if ((nextDate - acc.Item1).Days == 1)
                                                                                 {
                                                                                     daysSoFar++;                                                                                
                                                                                 }
                                                                                                                                                                                                                                       
                                                                                 return Tuple.Create(nextDate, daysSoFar);                                                                          
                                                                             },
                                                                             acc => acc.Item2);
