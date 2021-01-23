    static void Main(string[] args)
        {
            Console.WriteLine("Geef een getal in?");
            double getal1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Geef een tweede getal in?");
            double getal2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Geef een derde getal in?");
            double getal3 = Convert.ToDouble(Console.ReadLine());
            if (getal1 > getal2 && getal1  > getal3)
            {
                Console.WriteLine(getal1 + "is het grootste getal");
           
            }
            if (getal2 > getal1 && getal2 > getal3) 
            {
                Console.WriteLine(getal2 + "is het grootste getal");
            }
            if( getal3 > getal2 && getal3 > getal1 )
            {
                Console.WriteLine(getal3 + "is het grootste getal");
            }
        }
