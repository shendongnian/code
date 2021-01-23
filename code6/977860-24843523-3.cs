    public class MyData
    {
        public readonly string DateDetails;
        public static List<MyData> Create(params string [] dates)
        {
            return dates.Select(x => new MyData(x)).ToList();
        }
        public MyData(string dateDetails)
        {
            this.DateDetails = dateDetails;
        }
        public override string ToString()
        {
            return DateDetails;
        }
    }
            var recordList = MyData.Create("1707 ABCD", "1707 XXXX", "1725 DEFG", "1725 HIJK", "1725 LMNOP");
            for (int i = 0; i < recordList.Count; i++)
            {
                var index = recordList.BinarySearch(recordList[i], new RecComparer());
                Debug.Assert(index == i);
            }
