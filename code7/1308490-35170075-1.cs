    class Program
    { 
       public  struct course
       {
            public string name;
            public void getdetails()
            {
                Console.WriteLine("Enter your Name");
                name = Console.ReadLine();
            }
       }
    
        static void Main(string[] args)
        {    
            course ele = new course();
            ele.getdetails();
        }
    }
