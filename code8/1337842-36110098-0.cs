     var data = new string[5,4]
                {
                     { "ID", "Status", "Available", "Count" },
                    { "------", "------", "------", "------" },
                    { "1123", "True", "False", "-1" },
                    { "23", "False", "True", "-23" },
                    { "3", "True", "True", "-1" }
    
                };
                for (int i = 0; i < data.GetLength(0); i++)
                {
                    Console.WriteLine("{0,-10}\t{1,-10}\t{2,-10}\t{3,-10}", data[i, 0], data[i, 1], data[i, 2], data[i, 3]);
    
                }
