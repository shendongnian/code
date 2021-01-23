    using System;
    
    namespace Program
    {
        class Program
        {
            static decimal[,] factors = new decimal[4, 4] {
                /*               To Milli        To Micro    To Nano,  To Pico    */
                /* From Milli */ { 1m,           1000m,      1000000m, 1000000000m },
                /* From Micro */ { 0.001m,       1m,         1000m,    1000000m    },
                /* From Nano  */ { 0.000001m,    0.001m,     1m,       1000m       },
                /* From Pico  */ { 0.000000001m, 0.000001m,  0.001m,   1m          }
            };
    
            static void Main()
            {
                Console.WriteLine("SI converter!");
    
                while(true)
                {
                    Console.Write("Please, enter value: ");
                    decimal value = Convert.ToInt32(Console.ReadLine());
    
                    Console.Write("\n1) Milli(m)\n2) Micro(µ)\n3) Nano(n)\n4) Pico(p)\nFrom Units: ");
                    int fromUnits = int.Parse(Console.ReadLine()) - 1;
    
                    Console.Write("To Units: ");
                    int toUnits = int.Parse(Console.ReadLine()) - 1;
    
                    decimal factor = factors[fromUnits, toUnits];
                    decimal answer = factor * value;
                    Console.WriteLine("The answer is : " + answer);
    
                    Console.Write("Go again? (Y/N): ");    
                    string ans = Console.ReadLine();
    
                    if(ans.ToUpper() == "N")
                        break;
                }
            }
        }
    }
