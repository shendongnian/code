    using System;
    
    namespace RainfallHW
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] months;
                double[] rain;
                double avg;
                double sum = 0;
                double value;
                string input;
                bool isValid = false;
    
    
                months = new string[12] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                rain = new double[12];
    
                for (int i = 0; i < rain.Length; i++)
                {
                    Console.Write("Rainfall in {0}: ", months[i]);
    
                    while (!isValid)
                    {
                        input = Console.ReadLine();
                        //TryParse returns true if input is a number
                        //Then check for > 0
                        if (double.TryParse(input, out value) && double.Parse(input) > 0)
                        {
                            rain[i] = double.Parse(input);
                            sum += rain[i]; //update the sum here instead of its own loop
                            isValid = true;
                        }
                        else 
                        {
                            Console.Write("Rainfall in {0}: ", months[i]);
                        }
                    }
                }
                avg = sum / 12;
                Console.WriteLine("");
                Console.WriteLine("Average Month Rain: {0}", avg);
            }
        }
    }
