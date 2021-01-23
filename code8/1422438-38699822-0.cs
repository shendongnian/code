            Program a = new Program();
            string n=a.nameCheck(name);
            Console.WriteLine("Hallo " + n);
            Console.ReadLine();
          private string nameCheck(string n)
        {
            if (n == "")
            {
               // Console.WriteLine("Geben Sie einen Namen ein");
                return "Geben Sie einen Namen ein";
            }
            return n;
        }
