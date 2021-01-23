         static void Main(string[] args)
        {
            List<favorite> f = new List<favorite>();
            f.Add(new favorite { id = 1, title = "MEN" });
            f.Add(new favorite { id = 2, title = "WOMEN" });
            f.Add(new favorite { id = 3, title = "BOYS" });
            f.Add(new favorite { id = 4, title = "GIRLS" });
            f.Add(new favorite { id = 5, title = "Ajay" });
            f.Add(new favorite { id = 6, title = "vijay" });
            f.Add(new favorite { id = 7, title = "Jitu" });
            f.Add(new favorite { id = 8, title = "Suresh" });
            f.Add(new favorite { id = 9, title = "Ramesh" });
            f.Add(new favorite { id = 10, title = "Akshay" });
            var list = f.OrderByDescending(e => IsAllUpper(e.title)).ThenBy(e => e.title).ToList();
            foreach (var item in list)
            {
                Console.WriteLine(item.title);
            }
            Console.ReadLine();
        }
        class favorite
        {
            public int id { get; set; }
            public string title { get; set; }
        }
        static bool IsAllUpper(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsLetter(input[i]) && !Char.IsUpper(input[i]))
                    return false;
            }
            return true;
        }
