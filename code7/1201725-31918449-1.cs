            int n, p, q;
            string input;
            Int32.TryParse(Console.ReadLine(), out n);            
            while (!string.IsNullOrWhiteSpace((input = Console.ReadLine())))
            {                
                Int32.TryParse(input, out p);
                Int32.TryParse(Console.ReadLine(), out q);                
            }
            Console.ReadKey();
