     class Program
    {
        static void Main(string[] args)
        {
            string[] unsorted = System.IO.File.ReadAllLines(@"\University\AlgRetake\Files\WS1_AF.txt");
            //Grabs the .txt file and reads line by line
    
            System.Console.WriteLine("Unsorted: ");
            foreach (string line in unsorted)
            {
                ****Console.WriteLine(line);****
            }
            //outputs the unsorted array
    
    
            Console.WriteLine("Press any key to exit!");
            System.Console.ReadKey();
    
        }
    } 
