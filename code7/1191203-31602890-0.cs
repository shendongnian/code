    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Globalization;
    namespace DateTimeConvert
    {
        class Program
        {
            static void Main(string[] args)
            {
                var text1 = "19/05/2015"; //dd/mm/yyyy format
                var text2 = "05/19/2015"; //mm/dd/yyyy format
                var result = DateTime.Now;
                DateTime.TryParse(text1, out result);
                Console.WriteLine(result);
            
                DateTime.TryParse(text2, out result);
                Console.WriteLine(result);
                //Depending on computer's current culture format this will cause an error due to dd/MM/yyyy CULTURE format
                //DateTime date = (DateTime)Convert.ChangeType(text1, typeof(DateTime));
                var date = DateTime.ParseExact(text1, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                Console.WriteLine(date);
                Console.ReadLine();
            }
        }
    }
