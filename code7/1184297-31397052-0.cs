            var inputDate = "4/28/2006 12:39:32:429AM";
            //1 - parse into date parts
            char[] delimiterChars = { '/' };
            string[] dateParts = inputDate.Split(delimiterChars);
            var month = int.Parse(dateParts[0].ToString());
            var day = int.Parse(dateParts[1].ToString()); 
            var year = 0;
            string yearString = dateParts[2].ToString();
            //strip of the time for the year part
            if (yearString.Length > 5)
                year = int.Parse(yearString.Substring(0, 4));
            //2 - Create date object
            DateTime testDate = new DateTime(year, month, day);
            //3 - format date
            var outputDate = testDate.ToString("yyyyMMdd");
            Console.WriteLine("Input date: " + inputDate);
            Console.WriteLine("Output date: " + outputDate);
            Console.ReadLine();
