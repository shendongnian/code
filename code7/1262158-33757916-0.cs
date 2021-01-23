            string input = "1 year amount 2000,2 year amount 4000";
            List<string> parts = input.Split(',').ToList();
            if (parts != null && parts.Any())
            {
                parts.ForEach((s) =>
                {
                    Console.WriteLine(s);
                });
            }
            Console.ReadLine();
