    public class SearchResult
    {
        public bool success { get; set; }
        public SearchData data { get; set; }
    }
    public class SearchData
    {
        public string UploadDate { get; set; }
        public IEnumerable<UserImages> Images { get; set; }
    }
    public class UserImages
    {
        public string Filename { get; set; }
        public string FileId { get; set; }
    }
    public class FlatData
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
    }
            
    public static void Test()
    {
        //generate arbitrary dates to group on
        var dates = Enumerable.Range(0, 3).Select(x => DateTime.Today.AddDays(x)).ToArray();
        //generate some sample data in the flat format
        var flatData = Enumerable.Range(1, 10).Select(x => new FlatData() { Id = x.ToString(), Name = "Image_" + x, Date = dates[x % 3] });
        //group the flat data into the hierarchical format
        var grouped = from item in flatData
                      group item by item.Date into g
                      select new SearchData()
                      {
                          UploadDate = g.Key.ToShortDateString(),
                          Images = from img in g
                                   select new UserImages()
                                   {
                                       FileId = img.Id,
                                       Filename = img.Name
                                   }
                      };
        //Serialization implementation abstracted, as it should be
        var json = Common.Helper.SerializeJSON(grouped);
    }}
