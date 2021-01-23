    using System;
    
    class Prime_Screening
        {
        bool prime;
        static void Main()
            {
            Console.WriteLine("Prime numbers x, where: 0 < x < 100");
    
                for (int num= 2; num<= 100; num++)
                {
                    prime = True;
                    for (int div= 2; div<= Math.Sqrt(num); div++)
                        if(num % div== 0)
                            prime = False;
                    if (prime)
                        Console.Write(num.ToString() + ", ");
                }
            } 
        }
