    public class Datum
    {
        public string ID { get; set; }
        public string name { get; set; }
        public string objCode { get; set; }
        public double percentComplete { get; set; }
        public string plannedCompletionDate { get; set; }
        public string plannedStartDate { get; set; }
        public int priority { get; set; }
        public string projectedCompletionDate { get; set; }
        public string status { get; set; }
    }
    public class RootObject
    {
        public List<Datum> data { get; set; }
    }
