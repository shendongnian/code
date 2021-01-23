    class Program
    {
        static void Main(string[] args)
        {
            string sampleJson = @"{ ""coordinates"": [
                [
                    [-3.213338431720785, 55.940382588499197],
                    [-3.213340490487523, 55.940381867350276],
                    [-3.213340490487523, 55.940381867350276],
                    [-3.213814166228732, 55.940215021175085],
                    [-3.21413960035129, 55.940100842843712]
                ]
            ]}";
    
            dynamic d = JObject.Parse(sampleJson);
    
            Console.WriteLine(d.coordinates[0].Count);
            foreach (var coord in d.coordinates[0])
            {
                Console.WriteLine("{0}, {1}", coord[0], coord[1]);
            }
    
       Console.ReadLine();
    }
