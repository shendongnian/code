    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    namespace DownloadString
    {
        class Program
        {
            static void Main(string[] args)
            {
                WebClient client = new WebClient();
                Uri uri = new Uri("http://www.carsireland.ie/car-dealers/county/donegal/prestige-cars-ireland-ltd.");
                string str = client.DownloadString(uri);
                Console.WriteLine(str);
                Console.ReadKey();
            }
        }
    }
