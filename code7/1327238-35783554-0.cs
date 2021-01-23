    public class Dates
    {
    public string IncDate;
    public string ExpDate;
    }
    
        Dates[] result =  Dt.AsEnumerable()
        .Select(r => new Dates{IncDate = r.Field<string>("IncDate"), ExpDate = r.Field<string>("ExpDate") })
        .ToArray();
