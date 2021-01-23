    public class ITaskData
    {
        public List<KeyValuePair<object, object>> keyValuePairs { get; set; }
    }
    class Program
    {
        private static List<ITaskData> list = new List<ITaskData>();
        private static void Main()
        {
            List<KeyValuePair<object, object>> result = new List<KeyValuePair<object, object>>();
            foreach (var a in list)
                foreach (var b in a.keyValuePairs)
                    if (b.Value.ToString().Contains("Stockroom")) result.Add(b); 
                    // Here I make .ToString().Contains("Stockroom")
                    // You can add any required logics here
        }
    }
