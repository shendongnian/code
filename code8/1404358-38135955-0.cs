    public class Program
      {
       string name;
       public void GetName()
       {
           Console.WriteLine("Enter ur name");
           name = Console.ReadLine();
           Console.WriteLine("Name is {0}",name);
           Console.ReadLine();
    
       }
    
        static void Main()
        {
            Program p = new Program();
            p.GetName();
            Console.ReadLine();
        }
    
    }
