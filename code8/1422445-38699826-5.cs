    class program
    {
        Main() 
        {
            //...
            Program p = new Program();
            string name = ...
            name = p.checkName(name);
        }
        private string nameCheck(string name)
        {
            if (name == "")
            {
                Console.WriteLine("Geben Sie einen Namen ein");
                name = Console.ReadLine();
            }
            return name;
        }
    }    
