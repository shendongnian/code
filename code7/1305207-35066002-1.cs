    public class RootObject
    {
       public void AddRow(int id, string name, int year, int month, int data)
       {
          if(!categories.Contains(year + month))
          {
             categories.Add(year + month);
          }
          var serie = series.Where(x => x.name == name).FirstOrDefault();
          if(serie == null)
          {
             serie = new Series();
          }
          serie.data.Add(data);
        }
        public List<int> categories { get; set; }
        public List<Series> series { get; set; }
    }
    public class Series
    {
        public string name { get; set; }
        public List<int> data { get; set; }
    }
