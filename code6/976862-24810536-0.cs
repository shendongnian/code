    class Program
    {
        static void Main(string[] args)
        {
            var data = new List<DataPoint>
                       {
                           new DataPoint(){Condition = true, Value = 0, Values = new List<int>{1,2,3}},
                           new DataPoint(){Condition = false, Value = 10, Values = new List<int>{}},
                           new DataPoint(){Condition = true, Value = 0, Values = new List<int>{4,5}},
                           new DataPoint(){Condition = false, Value = 20, Values = new List<int>{}}
                       };
            var sum = data.Sum(s=>s.Condition?s.Values.Sum():s.Value);
        }
    }
    internal class DataPoint
    {
        public bool Condition { get; set; }
        public int  Value { get; set; }
        public List<int> Values { get; set; }
    }
