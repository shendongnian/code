    static void Main(string[] args)
    {
       while (true) 
       {
            Console.Write("> ");
            string command = Console.ReadLine().ToLower();
    
            if (command == "add)
            {
                Add(); // Call our Add method
            }
            else if (command == "subtract")
            {
                Subtract(); // Call our Subtract method
            }
            else if (command == "multiply")
            {
                Multiple(); // Call our Multiply method
            }
            else if (command == "exit")
            {
                break; // Break the loop
            }
       }
    }
    
    static void Add()
    {
    
    }
    
    static void Subtract()
    {
    
    }
    
    static void Multiply()
    {
    
    }
