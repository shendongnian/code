    class Program
    {
        static void Main()
        {
            DataString dataStr = new DataString();
    
            // Assigning the dataStr property causes the 'set' accessor to be called.
            dataStr.Data = "some string";
    
            // Evaluating the Hours property causes the 'get' accessor to be called.
            System.Console.WriteLine(dataStr.Data); //this will display "some string"
        }
    }
