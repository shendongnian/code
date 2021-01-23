        public class CrateDimensions
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
    }
    class Program
    {
        static List<CrateDimensions> crates = new List<CrateDimensions>();
        static void Main(string[] args)
        {
            GetCrateDim();
        }
        static void GetCrateDim()
        {
            double l = GetDim("Please enter the crate Length for your incoming shipment");
            double w = GetDim("Please enter the crate Width for your incoming shipment");
            double h = GetDim("Please enter the crate Height for your incoming shipment");
            crates.Add(new CrateDimensions() { Height = h, Length = l, Width = w });
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
        static double GetDim(string message)
        {
            Console.WriteLine(message + ": ");
            double dimLen = 0;
            while (!double.TryParse(Console.ReadLine(), out dimLen))
                Console.WriteLine("Please enter a valid number");
            return dimLen;
        }
}
