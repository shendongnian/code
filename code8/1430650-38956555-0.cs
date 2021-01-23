    static double InputFuel()
        {
            double fFuel;
            string text;
            bool badValue = true;
            bool notFirst = false;
            do
            {
                if(!notFirst)
                    Console.Write("Enter amount of fuel used in litres : ");
                notFirst = true;
                text = Console.ReadLine();
                if (double.TryParse(text, out fFuel) && fFuel >= 20)
                {
                    badValue = false;
                }
                else
                {
                    Console.WriteLine("\n\t {0} is below the minimum value of 20  \n\n", text);
                    Console.Write("Please re-enter number greater than 20 : ");
                }
            } while (badValue);
            return fFuel;
        }
