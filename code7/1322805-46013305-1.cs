    public class TopUser
    {
        public string Name { get; set; }
        public int Count { get; set; }
    }
    var result = Helper.RawSqlQuery(
        "SELECT TOP 10 Name, COUNT(*) FROM Users U"
        + " INNER JOIN Signups S ON U.UserId = S.UserId"
        + " GROUP BY U.Name ORDER BY COUNT(*) DESC",
        x => new TopUser { Name = (string)x[0], Count = (int)x[1] });
    result.ForEach(x => Console.WriteLine($"{x.Name,-25}{x.Count}"));
