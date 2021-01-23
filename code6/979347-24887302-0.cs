    static void Main(string[] args)
        {            
            var victimCount=0;
            var f1 = 0.0;
            var f2 = 1.0;
            var f3 = 0.0;
            while (victimCount<2)
            {
                Console.Write("Enter the number of victims so we can predict the next murder, Sherlock: ");
                //see if you can parse it and that the number is larger than 1
                //that's assuming that not only 1 is invalid 
                //but also 0 and negative numbers
                //using tryparse ensures that even if the user types letters
                //your program won't crash
                if(!int.TryParse(Console.ReadLine(),out victimCount) || victimCount < 2){
                    Console.Write("that's an invalid number.");
                }
            }                 
            for (var i = 0; i <= victimCount; i++)
            {
                f3 = f1 + f2;
                f1 = f2;
                f2 = f3;
                Console.WriteLine("Victim " + f1);
            }
            Console.ReadLine();
        }
