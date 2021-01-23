     public class DoStuff
        {
            public string _datafile = "hello world";
            public void ShowVariable()
            {
                Console.WriteLine(this.GetType().GetField("_datafile").GetValue(this));
    
    
                //Desired output:
                //Hello world
    
            }
    
        }
    
        class Program
        {
    
            static void Main(string[] args)
            {
                new DoStuff().ShowVariable();
                Console.ReadLine();
            }
    }
