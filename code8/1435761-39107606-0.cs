    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<DataResponse>();
            list.Add(new DataResponse() { Stuff = 1, Stuff2 = 2 });
            list.Add(new DataResponse() { Stuff = 1, Stuff2 = 2 });
            var response = DoAggregation(list);
        }
        public static DataAggragationResponse DoAggregation(List<DataResponse> lst)
        {
            if (lst.Count == 0)
                return null;
            DataAggragationResponse aggrResponse = new DataAggragationResponse();
            foreach (PropertyInfo propertyInfo in typeof(DataResponse).GetProperties())
            {
                aggrResponse.GetType().GetProperty(propertyInfo.Name).SetValue(aggrResponse, lst.Sum(x => (int)x.GetType().GetProperty(propertyInfo.Name).GetValue(x)));
            }
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
