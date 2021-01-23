    class Program
    {
        int answer;
    	int number;
    	int numbera;	
        public void detail()
        {
            Console.WriteLine("Multiplication Calculator.");	
    		
            string input;
    		
            Console.WriteLine("Number 1: ");
    		input = Console.ReadLine();
    		Int32.TryParse(input, out number);
    		
            Console.WriteLine("Number 2: ");   
    		input = Console.ReadLine();
            Int32.TryParse(input, out numbera);
        }
        public void calculations()
        {
            answer = number * numbera;
        }
        public void display()
        {
            Console.WriteLine();
            Console.WriteLine(answer);
        }
    }
    class call
    {
        static void Main()
        {
            Program r = new Program();
            r.detail();
            r.calculations();
            r.display();
        }
    }
