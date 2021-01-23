    class ArrayProgram
    {
        public bool ElementAt(int[] intArray, int valueToBeFound)
        {
            foreach (int x in intArray)     
                if (x == valueToBeFound)        // if you found your value in the array
                    return true;                // you return true
            return false;   // otherwise, by this point the foreach has looped through all the elements and hasn't once entered in the above if (so it hasn't found your value) = you return false
        }
        public void RunProgram()
        {
            int[] intArray = { 20, 30, 40, 50, 60, 50, 40, 30, 20, 10,99 };
            int numberTofind;
            Console.Write("Please enter the number you wish to search for within the array: ");
            numberTofind = Convert.ToInt32(Console.ReadLine());
            if(ElementAt(intArray, numberTofind))
                Console.WriteLine("{0} is in the array!", numberTofind);
            else
                Console.WriteLine("{0} is not in the array.", numberTofind);
        }  // end RunProgram()
        static void Main(string[] args)
        {
            ArrayProgram myArrayProgram = new ArrayProgram();
            myArrayProgram.RunProgram();
            Console.WriteLine("\n\n===============================");
            Console.WriteLine("ArrayProgram: Press any key to finish");
            Console.ReadKey();
        }
    }
