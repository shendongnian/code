    public class BugModel
    {
        public string BugState { get; set; }
        public Dictionary<string, int> Details { get; set; }
        public int Total { get { return Details.Sum(x => x.Value); } }
    }
        
    var result = (from bug in BugListGroup
                  group bug by bug.BugState into sub
                  select new BugModel
                  {
                      BugState = sub.Key,
                      Details = sub.GroupBy(x => x.BugSeverity)
                                 .ToDictionary(x => x.Key, x => x.Sum(y => y.BugCount))
                  }).ToList();
