        static void Main(string[] args)
        {
            string x = "[[99,\"abc\",\"2dp\",{\"Group\": 0,\"Total\":[4, 1]}],[7,\"x\",\"date\"],[60,\"x\",\"1dp\",{\"Group\": 1}]]";
            List<List<object>> xobj = JsonConvert.DeserializeObject<List<List<object>>>(x);
            for (int i = 0; i < xobj.Count; i++)
            {
                // Do something with index 0 to 3
                if (xobj[i].Count == 4)
                {
                    // I have the optional entry with Group & Total properties
                    dynamic opt = xobj[i][3];
                    Console.WriteLine("GROUP: " + opt.Group); // Mandatory
                    if (opt["Total"] != null)
                    {
                        Console.WriteLine("TOTAL: " + opt.Total[0]);
                    }
                }
            }
            Console.ReadLine();
        }
