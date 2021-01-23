            string source = "12345.63";
            if (Regex.IsMatch(source, @"^[0-9]{5}\.[0-9]{2}$"))
            {
                Console.WriteLine(source);
            }
            else
            { 
                Console.WriteLine("Not Match");
            }
            Console.ReadKey();
