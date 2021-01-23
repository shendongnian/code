       public static void Main()
        {
    
        string line;
        bool IsEmptyString = false;
        List<string> lines = new List<string>();
        using (System.IO.StreamReader currencies = new System.IO.StreamReader("currencies.txt")
        {
            while ((line = currencies.ReadLine()) != null)
            {
                lines.Add(line);
            }
        }
        
        while (!IsEmptyString)
        {
            string tempLine = "";
            Console.Write("Enter currency code >");
            string currency = Console.ReadLine();
            IsEmptyString = currency == "" ? true : false;
            tempLine = lines.FirstOrDefault(x => x.Contains(currency));
            if (tempLine!="")
             {
                    Console.WriteLine(tempLine);
             }
            tempLine = "";
            
        }
     
    }
