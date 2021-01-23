            static void Main(string[] args)
        {
            GetCrateDim();
        }
        static void GetCrateDim()
        {
            double l = GetDim("Please enter the crate Length for your incoming shipment");
            double w = GetDim("Please enter the crate Width for your incoming shipment");
            double h = GetDim("Please enter the crate Height for your incoming shipment");
            double totalDims = new double();
            totalDims = l* w * h;
            double volKg = new double();
            volKg = totalDims / 366;
            Console.WriteLine("Your total Vol Kg is {0:0.00}", +volKg);
            Console.Write("Are there any additional crates y/n? ");
            char a = new char();
            a = char.Parse(Console.ReadLine().ToLower());
            if (a == 'y')
                GetCrateDim();
        }
        static long GetDim(string message)
        {
            Console.WriteLine(message + ": ");
            long dimLen = 0;
            while (!long.TryParse(Console.ReadLine(), out dimLen))
                Console.WriteLine("Please enter a valid number");
            return dimLen;
        }
