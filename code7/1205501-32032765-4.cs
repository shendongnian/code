            Console.Write("[");
            foreach (var e in list)
            {
                Console.Write("{ ");
                foreach (var f in e.GetType().GetFields().OrderBy(f=>f.Name))
                {
                    if (f.Name == "Date")
                    {
                        Console.Write(string.Format("Date = \"{0}\" ", f.GetValue(e)));
                    }
                    else
                    {
                        Console.Write(string.Format(", {0} = {1} ",f.Name, f.GetValue(e)));
                    }
                }
                Console.Write(" },");
            }
            Console.Write("]\n");
