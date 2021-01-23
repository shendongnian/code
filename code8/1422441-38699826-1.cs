    class program
    {
        private string name;
        Main() 
        {
            //...
            Program p = new Program();
            p.Name = p.checkName();
        }
        private void nameCheck()
        {
            if (this.name == "")
            {
                Console.WriteLine("Geben Sie einen Namen ein");
                this.name = Console.ReadLine();
            }
        }
    }
