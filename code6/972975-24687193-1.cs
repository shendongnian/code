    var obj = JsonConvert.DeserializeObject<MyObject>(json);
---
    public class MyObject
    {
        public Dictionary<string,Item> SkillsMetrics { set; get; }
        public Item MetricsTotals { set; get; }
    }
    public class Item
    {
        public int avgTimeToAbandon { get; set; }
        public int totalTimeToAnswer { get; set; }
        public int totalTimeToAbandon { get; set; }
        public int enteredQEng { get; set; }
        public int avgTimeToAnswer { get; set; }
        public double abandonmentRate { get; set; }
        public int abandonedEng { get; set; }
        public int connectedEng { get; set; }
    }
