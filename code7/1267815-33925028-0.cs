    class Class1
    {
        var rand = new Random();
        var alist;
    
        public Class1() // constructor creates a new list and initializes it
        {
            alist = new List<double>();
            for (int i = 0; i < 50; i++)
            {
                alist.Add(rand.Next(10)); 
            }
        }
    
    
        public List<double> TotalSum()
        {
            Console.WriteLine("Total sum:", alist.Sum());
        }
    
        public List<double> Sort()
        {
            alist.Sort();   
            for (double num in alist)
            {
                Console.WriteLine(num.ToString());
            }
            
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                Class1 show = new Class1();
                show.TotalSum();
                show.Sort();
            }
        }
    }
