    public class Rootobject
    {
    public Movie movie { get; set; }
    }
    public class Movie
    {
    public string id { get; set; }
    public string title { get; set; }
    public int year { get; set; }
    public Release_Dates release_dates { get; set; }
    public Ratings ratings { get; set; }
    public Abridged_Cast[] abridged_cast { get; set; }
    public string hashKey { get; set; }
    }
    public class Release_Dates
    {
    public string theater { get; set; }
    public string dvd { get; set; }
    }
    public class Ratings
      {
    public string critics_rating { get; set; }
    public int critics_score { get; set; }
    public string audience_rating { get; set; }
    public int audience_score { get; set; }
    }
    public class Abridged_Cast
    {
    public string name { get; set; }
    public string id { get; set; }
    public string[] characters { get; set; }
    }
