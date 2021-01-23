        public static void SearchDetails()
        {
        Console.WriteLine("Enter ID Number");
        int Id = 0;
        int.TryParse(Console.ReadLine(), out Id);
     string[] lines = System.IO.File.ReadAllLines(@"C:\\file.txt");
                List<string> IdLines = lines.Where((x, i) => i % 4 == 0).ToList();
                int IdLine = IdLines.IndexOf(Id);
                if (IdLine != -1)
                { //then result found
                    //Id is what user searched for or
                   // string Id = lines[IdLine*4];
                    //string[] results = lines.Where((x, i) => i > IdLine * 4 && i < IdLine * 4 + 4).ToArray();
               for(int i=IdLine*4;i<IdLine*4+4;i++)
                System.Console.WriteLine(lines[i]);
                }
                else
                {
                    Console.WriteLine("no results!");
                } 
        
        }
