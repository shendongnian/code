    public class MyTable
    {
        public int? Id {get;set;}
        public string Title {get;set;}
        public int? BugNumber {get;set;}
        
        public override string ToString()
        {
            return String.Format(" {0}, {1}, {2}", Id, Title, BugNumber.Value);
        }
    }
    public class MyTableGroup
    {
        public int? BugNumber {get;set;}
        public List<MyTable> Values{get;set;}
    }
    var data = new List<MyTable>()
    {
        new MyTable() { Id = 1, Title = "row1", BugNumber=224 },
        new MyTable() { Id = 2, Title = "row2", BugNumber=321 },
        new MyTable() { Id = 3, Title = "row3", BugNumber=224 },
        new MyTable() { Id = 4, Title = "row4", BugNumber=123 }
    };
    var result = new List<MyTableGroup>();
    var groupResult = data.GroupBy(s => s.BugNumber);
     foreach (var group in groupResult)
     {
         result.Add(new MyTableGroup()
         {
             BugNumber = group.Key,
             Values = group.ToList()
         });
     }
