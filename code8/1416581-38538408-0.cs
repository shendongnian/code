    public class GonnaSortThisData
    {
        public GonnaSortThisData()
        {
            List<Data> dataValues = new List<Data>
            {
                new Data {OwnerId = 123, Status = Status.New, Date = DateTime.Parse(@"2016-01-01")},
                new Data {OwnerId = 456, Status = Status.New, Date = DateTime.Parse(@"2016-01-01")},
                new Data {OwnerId = 789, Status = Status.New, Date = DateTime.Parse(@"2016-01-06")},
                new Data {OwnerId = 123, Status = Status.New, Date = DateTime.Parse(@"2016-01-05")},
                new Data {OwnerId = 456, Status = Status.Qualified, Date = DateTime.Parse(@"2016-01-05")},
                new Data {OwnerId = 789, Status = Status.Converted, Date = DateTime.Parse(@"2016-01-01")},
                new Data {OwnerId = 123, Status = Status.Qualified, Date = DateTime.Parse(@"2016-01-02")}
            };
            //var = List<Data>
            var sortedValues = dataValues
                .OrderBy(list => list.OwnerId)
                .ThenBy(list => list.Status)
                .ThenByDescending(list => list.Date).ToList();
        }
    }
    public class Data
    {
        public dynamic OwnerId { get; set; }
        public Status Status { get; set; }
        public DateTime Date { get; set; }
    }
    public enum Status
    {
        New, Qualified, Converted
    }
