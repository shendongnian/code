    namespace Climate_Sorting_Application
    {
    
        public class ClimateRecord
        {
            public DateTime RecordDate {get;set;}
            public int StationId {get;set;}
            public double RainFall {get;set;}
            public double Sun {get;set;}
            public double TMax {get;set;}
            public double TMin {get;set;}
            public double AF {get;set;}
            public override string ToString()
            {
                return String.Format("{0,-15:MMMM yyyy}{1,4}{2,8:F4}{3,8:F4}{4,8:F4}{5,8:F4}{6,8:F4}{7,8:F4}",
                    RecordDate, StationId, AF, RainFail, Sun, TMax, TMin);
            }
        }
    
        public class Program
        {
            static IList<ClimateRecord> LoadData()
            {
                var result = new List<ClimateRecord>();
                using (var monthRdr = new StreamReader("Month.txt"))
                using (var yearRdr = new StreamReader("Year.txt"))
                using (var afRdr1 = new StreamReader("WS1_AF.txt"))
                using (var rainRdr1 = new StreamReader("WS1_Rain.txt"))
                using (var sunRdr1 = new StreamReader("WS1_Sun.txt"))
                using (var tmaxRdr1 = new StreamReader("WS1_TMax.txt"))
                using (var tminRdr1 = new StreamReader("WS1_TMin.txt"))
                using (var afRdr2 = new StreamReader("WS2_AF.txt"))
                using (var rainRdr2 = new StreamReader("WS2_Rain.txt"))
                using (var sunRdr2 = new StreamReader("WS2_Sun.txt"))
                using (var tmaxRdr2 = new StreamReader("WS2_TMax.txt"))
                using (var tminRdr2 = new StreamReader("WS2_TMin.txt"))
                {
                     string item = yearRdr.ReadLine();
                     while (item != null)
                     {
                          int year = int.Parse(item);
                          int month = int.Parse(monthRdr.ReadLine());
                         
                          var ws1 = new ClimateRecord() {
                              RecordDate = new DateTime(year, month, 1),
                              StationId = 1,
                              AF = double.Parse(afRdr1.ReadLine()),
                              Sun = double.Parse(sunRdr1.ReadLine()),
                              RainFall = double.Parse(rainRdr1.ReadLine()),
                              TMax = double.Parse(tmaxRdr1.ReadLine()),
                              TMin = double.Parse(tminRdr1.ReadLine())
                          };
                          var ws2 = new ClimateRecord() {
                              RecordDate = new DateTime(year, month, 1),
                              StationId = 2,
                              AF = double.Parse(afRdr2.ReadLine()),
                              Sun = double.Parse(sunRdr2.ReadLine()),
                              RainFall = double.Parse(rainRdr2.ReadLine()),
                              TMax = double.Parse(tmaxRdr2.ReadLine()),
                              TMin = double.Parse(tminRdr2.ReadLine())
                          };
                          result.Add(ws1);
                          result.Add(ws2);
                          item = yearRdr.ReadLine();
                     } 
                }
                return result;
            }
            static void PrintData(IEnumerable<ClimateRecord> data)
            {
               Console.WriteLine("{0,15}{1,4}{2,8}{3,8}{4,8}{5,8}{6,8}{7,8}",
                  "Month/Year", "WS", "AF", "Rain", "Sun", "T-Max", "T-Min");
               foreach (var record in data) Console.WriteLine(record);
            }
            static void Main(string[] args)
            {
                var climateData = LoadData();
                Console.WriteLine("Printing all data: ");
                PrintData(climateData);
                Console.WriteLine("\n\nPrinting Station 1 data:");
                PrintData(climateData.Where(r => r.StationId == 1));
 
                Console.WriteLine("\n\nPrinting Station 2 data:");
                PrintData(climateData.Where(r => r.StationId == 2));
                Console.WriteLine("\n\nPrinting Station 1 data ordered by rainfall descending:");
                PrintData(climateData.Where(r => r.StationId == 1).OrderBy(r => r.RainFall * -1));
            }
        }
    }
    
