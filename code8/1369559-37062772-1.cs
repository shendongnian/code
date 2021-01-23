        private static void Main(string[] args)
        {
            var employeeIDs = new List<string>();
            var employeeNames = new List<string>();
            var employeeSalaries = new List<string>();
            var tmp = "";
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
                            tmp = tmp + line[i];
                        }
                        else if (line[i] == ',')
                        {
                            if (isFirstColumn)
                            {
                                //This is the ID, because isFirstColumn is still set to true
                                employeeIDs.Add(tmp);
                                isFirstColumn = false;      //Next "," separates the name
                            }
                            else
                            {
                                //This is the name, because isFirstColumn is now false
                                employeeNames.Add(tmp);
                            }
                            tmp = "";
                        }
                        if (i == (line.Length - 1))
                        {
                            employeeSalaries.Add(tmp);
                            tmp = "";
                        }
                    }
                }
            }
            Console.WriteLine("Employee ID:");
            foreach (var num in employeeIDs)
            { 
                Console.WriteLine(num);
            }
            Console.WriteLine("name:");
            foreach (var name in employeeNames)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine("Salary");
            foreach (var salary in employeeSalaries)
            {
                Console.WriteLine(salary);
            }
            Console.ReadKey();
        }
