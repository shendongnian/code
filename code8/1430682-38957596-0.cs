    namespace ConsoleApplication1
    {
        using System.Linq;
    
        class Program
        {
            static void Main(string[] args)
            {
                string[] lines = new string[3];
    
                string data1 = "data1,data2,data3,data4";
                string data2 = ",,data3,data4";
                string data3 = "data1,data2,data3,";
    
                lines[0] = data1;
                lines[1] = data2;
                lines[2] = data3;
    
                var result = lines
                    .Select(line => line.Split(','))
                    .Where(linePart => linePart.All(part => !string.IsNullOrWhiteSpace(part)))
                    .ToList();
            }
        }
    }
