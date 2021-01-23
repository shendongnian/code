    class Program
    {
        static void Main(string[] args)
        {
            var ro = new RootObject();
            ro.AddRow(1, "Name1", 2015, 10, 4);
            ro.AddRow(1, "Name1", 2015, 11, 5);
            ro.AddRow(1, "Name1", 2015, 12, 6);
            ro.AddRow(2, "Name2", 2015, 10, 6);
            ro.AddRow(2, "Name2", 2015, 11, 7);
            ro.AddRow(2, "Name2", 2015, 12, 8);
            ro.AddRow(3, "Name3", 2015, 10, 35);
            ro.AddRow(3, "Name3", 2015, 11, 7);
            ro.AddRow(3, "Name3", 2015, 12, 8);
            string output = JsonConvert.SerializeObject(ro);
            Console.WriteLine(output);
            //Output:
            //{
            //    "categories":[10,11,12],
            //    "series":[
            //        {"name":"Name1","data":[4,5,6]},
            //        {"name":"Name2","data":[6,7,8]},
            //        {"name":"Name3","data":[35,7,8]}]
            //}
            Console.ReadKey();
        }
        public class RootObject
        {
            public RootObject()
            {
                categories = new List<int>();
                series = new List<Series>();
            }
            public void AddRow(int id, string name, int year, int month, int data)
            {
                if (!categories.Contains(month))
                {
                    categories.Add(month);
                }
                var serie = series.FirstOrDefault(x => x.name == name);
                if (serie == null)
                {
                    serie = new Series(name);
                    series.Add(serie);
                }
                serie.data.Add(data);
            }
            public List<int> categories { get; set; }
            public List<Series> series { get; set; }
        }
        public class Series
        {
            public Series(string _name)
            {
                name = _name;
                data = new List<int>();
            }
            public string name { get; set; }
            public List<int> data { get; set; }
        }
    }
