    using System;
    
    namespace RainfallHW
    {
        class Program
        {
            static void Main(string[] args)
            {
                string [] months;
                double[] rain;
                double avg;
                double sum = 0;
    
    
                months = new string [12] {  "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"};
                rain = new double[12];
    
                for (int i = 0; i < rain.Length; i++)
                {
                    Console.Write("Rainfall in {0}: ", months[i]);
                    rain[i] = double.Parse(Console.ReadLine());
    
                    while (rain[i] < 0)
                    {
                        Console.Write("Rainfall in {0}: ", months[i]);
                        rain[i] = double.Parse(Console.ReadLine());                    
                    }
                }
                
                for (int x = 0; x < rain.Length; x++)
                {
                    sum = sum + rain[x];
                }
                avg = sum / 12;
                Console.WriteLine("");
                Console.WriteLine("Average Month Rain: {0} ", avg);
            }
        }
    }
