    class program
    {
        Main() 
        {
            //...
            Program p = new Program();
            p.Name = p.checkName(p.Name);
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
