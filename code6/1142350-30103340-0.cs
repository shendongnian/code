    using System;
    class Program {
        static void Main(string[] args) {
            string line = "0;0;11289;950;9732;899;9886;725;32893;2195;38010;2478;46188;3330;";
            string[] values = line.Split(';');
            char pointName = 'A';
            for (int i = 0; i < values.Length - 1; i += 2) {
                string endProductLine = string.Format("point A;point {0};{1};{2}", pointName, values[i], values[i + 1]);
                Console.WriteLine(endProductLine);
                pointName++;
            }
        }
    }
