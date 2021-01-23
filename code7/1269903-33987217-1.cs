    namespace Your_Name_Space
    {
        class Your_Program
        {
            public static void Main(string[] args)
            {
                string file1 = System.IO.File.ReadAllText(@"D:\file1.txt");
    
                List<double> Array1 = new List<double>();
                List<double> Array2 = new List<double>();
                List<double> Array3 = new List<double>();
    
                IEnumerable<string> lines = File.ReadLines(@"D:\File1.txt");
    
                foreach (string line in lines)
                {
                    string[] columns = line.Split(',');
    
                    if (columns.Length != 3)
                    {
                        continue; // skips this line
                    }
    
                    Array1.Add(Convert.ToDouble(columns[0]));
                    Array2.Add(Convert.ToDouble(columns[1]));
                    Array3.Add(Convert.ToDouble(columns[2]));
                }
    
                Console.WriteLine(Max(Array1.ToArray()));
                Console.ReadKey();
            }
    
            public static double Max(double[] x)
            {
                double maxValue = x.Max();
                return maxValue;
            }
        }
    }
