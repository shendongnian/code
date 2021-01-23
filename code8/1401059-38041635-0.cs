            List<string> str = new List<string>() { "A01943486", "102-2009-1008", "A-146", "0622008081A", "Ematol OPBG", "Yavuz1098083", "Yeter1391671"};
            Regex reg = new Regex("[0-9]+");
            foreach (var item in str)
            {
                if (reg.IsMatch(item))
                {
                    Console.WriteLine(item);
                }
            }
