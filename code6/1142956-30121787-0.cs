    public class SOProblem1
    {
        public static void Main()
        {
            var records = new List<Record>
            {
                new Record {recordID = "1", recordName = "name1"},
                new Record {recordID = "2", recordName = "name2"},
                new Record {recordID = "3", recordName = "name3"},
                new Record {recordID = "4", recordName = "name4"},
                new Record {recordID = "1", recordName = "name1"},
                new Record {recordID = "2", recordName = "name2"},
                new Record {recordID = "3", recordName = "name3"}
            };
            var t = records.GroupBy(x => x.recordID);
            foreach (var record in t)
            {
                Console.WriteLine(record.Last().recordName);
            }
            Console.ReadKey();
        }
    }
    public class Record
    {
        public string recordID { get; set; }
        public string recordName { get; set; }
    }
