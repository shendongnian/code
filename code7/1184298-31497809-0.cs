            DateTime date;
            var inputDate = "4/28/2006 12:39:32";
            var outputDate = "Could not format the date.  The input date is not in a correct date format!";
            
            if (DateTime.TryParse(inputDate,out date))
            {
                outputDate = date.ToString("yyyyMMdd");
            }
            Console.WriteLine("Input date: " + inputDate);
            Console.WriteLine("Output date: " + outputDate);
            Console.ReadLine();
