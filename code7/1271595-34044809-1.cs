    public class SubDetail
    {
        public string Sub1 { get; set; }
        public string Sub2 { get; set; }
        public string Sub3 { get; set; }
    }
    public class RootObject
    {
        public string No { get; set; }
        public int Age { get; set; }
        public List<SubDetail> SubDetail { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            RootObject obj = new RootObject();
            obj.No = "1";
            obj.Age = 7;
            int lenght = 3;
            int counter = 0;
            for(int i=0; i<lenght; i++)
            {
                SubDetail detail = new SubDetail();
                detail.Sub1 = (counter + 1).ToString();
                detail.Sub2 = (counter + 1).ToString();
                detail.Sub3 = (counter + 1).ToString();
                if (obj.SubDetail == null)
                    obj.SubDetail = new List<SubDetail>();
                obj.SubDetail.Add(detail);
            }
            var jsonString = JsonConvert.SerializeObject(obj);
            Console.WriteLine(jsonString);
        }
    }
