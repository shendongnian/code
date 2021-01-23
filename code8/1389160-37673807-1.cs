            string Value= "12345.63";
            if (Regex.IsMatch(Value, @"^[0-9]{5}\.[0-9]{2}$"))
            {
                Console.WriteLine(Value);
            }
            else
            { 
                Console.WriteLine("Not Match");
            }
            Console.ReadKey();
