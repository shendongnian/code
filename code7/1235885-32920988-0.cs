        public class Choice
        {
            public string Name { get; set; }
            public string Response { get; set; }
            public Action Consequence { get; set; }
        }
        ...    
        List<Choice> chList = new List<Choice>();
        int nice=0;
        int good=0;
                
        chList.Add(new Choice() { Name="not nice", Response = "not nice!"    , Consequence = () => nice-- });
        chList.Add(new Choice() { Name="good"    , Response = "you did good" , Consequence = () => good++ });
        ...            
        bool correctOption = false;
        do{          
            string option = Console.ReadLine();
            foreach (Choice c in chList)
            {
                if (option == c.Name)
                {
                    Console.Out.WriteLine(c.Response);
                    c.Consequence();
                    correctOption = true;
                    break;
                }
            }
            if (!correctOption) Console.WriteLine("Try again");
        } while (!correctOption);
