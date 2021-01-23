    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<DataResponse>();
            list.Add(new DataResponse() { Stuff = 1, Stuff2 = 2 });
            list.Add(new DataResponse() { Stuff = 1, Stuff2 = 2 });
            Stopwatch watch = new Stopwatch();
            watch.Start();
            var response = DoAggregationReflection(list);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
            watch.Reset();
            watch.Start();
            var response2 = DoAggregation(list);
            watch.Stop();
            Console.WriteLine(watch.Elapsed.TotalMilliseconds);
        }
        public static DataAggragationResponse DoAggregationReflection(List<DataResponse> lst)
        {
            if (lst.Count == 0)
                return null;
            DataAggragationResponse aggrResponse = new DataAggragationResponse();
            var responseType = typeof(DataResponse);
            var aggrResponseType = typeof(DataAggragationResponse);
            foreach (PropertyInfo propertyInfo in typeof(DataResponse).GetProperties())
            {
                aggrResponseType.GetProperty(propertyInfo.Name).SetValue(aggrResponse, lst.Sum(x => (int)responseType.GetProperty(propertyInfo.Name).GetValue(x)));
            }
            return aggrResponse;
        }
        public static DataAggragationResponse DoAggregation(List<DataResponse> lst)
        {
            if (lst.Count == 0)
                return null;
            DataAggragationResponse aggrResponse = new DataAggragationResponse();
            aggrResponse.Stuff = lst.Sum(x => x.Stuff);
            aggrResponse.Stuff2 = lst.Sum(x => x.Stuff2);
            
            return aggrResponse;
        }
    }
    public class DataResponse
    {
        public int Stuff { get; set; }
        public int Stuff2 { get; set; }
    }
    public class DataAggragationResponse
    {
        public int Stuff { get; set; }
        public int Stuff2 { get; set; }
    }
