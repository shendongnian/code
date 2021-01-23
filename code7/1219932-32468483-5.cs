    // Create a class to store every tuple of your query.
    public class QueryTuple
    {
        public DateTime Date { get; set; }
        public string HighSchoolName { get; set; }
        public string HighSchoolName1 { get; set; }
        // For NULL values that maps to struct types, use Nullable<T>
        public Nullable<int> AwayScore {get; set; }
        // Nullable types can also be written with a ? after the type
        public int? HomeScore { get; set; }
    }
