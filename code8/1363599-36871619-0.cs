    namespace CrazyMaths
        {
            class Program
            {
                private List<int> storeValues;
                static int getMemory()
                {
                    Console.WriteLine("Please enter a number");
                    int locationChoice = int.Parse(Console.ReadLine());
    
                    int result = storeValues[locationChoice];
                    return result;
                }
    
        static void Main(string[] args)
        {
            storeValues = new List<int>();
        }
