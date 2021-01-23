    public static Tuple<DateTime, DateTime> Parse(this string input)
    {
        var parser = new Parser(new Options
        {
            FirstDayOfWeek = DayOfWeek.Monday
        });
    
        var span = parser.Parse(input);
    
        if (span.Start != null && span.End != null)
        {
            return Tuple.Create(span.Start.Value, span.End.Value);        
        }
    
        return null;
    }
