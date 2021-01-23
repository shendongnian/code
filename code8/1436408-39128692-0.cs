    public static void ApiMock(string s)
    {
      Console.WriteLine($"I worked on {s}!");
    }
    static void Main(string[] args)
    {
      var d =  new Dictionary<int, string> {
          {  1, "location-1" },
          {  2, "location-2" },
          {  3, "location-3" }
      };
      d.ToList().ForEach(x => ApiMock(x.Value));
      //I just want the second one
      d.Where(x => x.Value.Contains("-2")).ToList().ForEach(x => ApiMock(x.Value));
}
