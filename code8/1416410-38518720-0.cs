        namespace ConsoleApplication6
        {
           class Program
           {
                public string SSN { get; set; }
    
                // Return a hash code based on a point of unique string data.
                public override int GetHashCode()
                {
                    return SSN.GetHashCode();
                }
    
                public static void Main(string[] args)
                {
                    Program p = new Program();
                    Console.WriteLine("{0}",p.SSN);
                }
           }  
        }
