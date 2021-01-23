    public static class Extensions
    {
	    public static IEnumerable<Percentage> SubstituteMissingMinutes(this IEnumerable<Percentage> source)
	    {
		    if(source == null) throw new ArgumentNullException("source");
		    return SubstituteMissingMinutesImpl(source.OrderBy(p => p.Date)).Reverse();
	    }
	    private static IEnumerable<Percentage> SubstituteMissingMinutesImpl(IEnumerable<Percentage> source)
	    {
            Percentage previous = null;
            foreach (var Percentage in source)
            {
                if(previous != null)
                {
                    var counter = previous.Date;
                    while((counter = counter.AddMinutes(1)) < Percentage.Date){
                        yield return new Percentage{ Date = counter, Low = previous.Low, High = previous.High, Avg = previous.Avg };
                    }
                }
                previous = Percentage;
                yield return Percentage;
            }        
        }
    }
