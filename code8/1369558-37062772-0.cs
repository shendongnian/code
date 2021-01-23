    private static void Main(string[] args)
        {
            var columna1 = new List<string>();
            var columna2 = new List<string>();
            var columna3 = new List<string>();
            var palabra = "";
            using (var rd = new StreamReader(@"values.csv"))
            {
                while (!rd.EndOfStream)
                {
                    var line = rd.ReadLine();
                    bool isFirstColumn = true;          //Indicates we are looking for first column value at this time
                    for (int i = 0; i < line.Length; i++)
                    {
                        if (line[i] != ',')
                        {
                            palabra = palabra + line[i];
                        }
                        else if (line[i] == ',')
                        {
                            if (isFirstColumn)
                            {
                                //This is the ID, because isFirstColumn is still set to true
                                columna1.Add(palabra);
                                isFirstColumn = false;      //Next "," separates the name
                            }
                            else
                            {
                                //This is the name, because isFirstColumn is now false
                                columna2.Add(palabra);
                            }
                            palabra = "";
                        }
                        if (i == (line.Length - 1))
                        {
                            columna3.Add(palabra);
                            palabra = "";
                        }
                    }
                }
            }
            Console.WriteLine("Employee ID:");
            foreach (var num in columna1)
            { 
                Console.WriteLine(num);
            }
            Console.WriteLine("name:");
            foreach (var name in columna2)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Salary");
            foreach (var salary in columna3)
            {
                Console.WriteLine(salary);
            }
            Console.ReadKey();
        }
