    private static void SelectMenuOption()
        {
            bool tf = true;
            while (tf)
            {
                Menu();
                string userInput = Console.ReadLine().ToLower();
                Console.WriteLine("--------------------------------------------------");
                string id = string.Empty;
                if (userInput == "text_00")
                {
                    Console.Write(CallDatabase("00"));
                    id = "00";
                    tf = false;
                }
                else if (userInput == "text_01")
                {
                    Console.Write(CallDatabase("01"));
                    id = "01";
                    tf = false;
                }
                else if (userInput == "text_02")
                {
                    Console.Write(CallDatabase("02"));
                    id = "02";
                    tf = false;
                }
                else if (userInput == "quit")
                {
                    tf = false;
                }
                else
                {
                    Console.WriteLine("Error");
                }
                var chage  = Console.ReadLine();
                Replace(id, chage);
                Console.Clear();
            }
        }
        private static void Replace(string id, string chage)
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(@"Database.xml");
            XmlNodeList elements = xml.SelectNodes("//Text");
           
            foreach (XmlNode element in elements)
            {
                if (element.Attributes["Id"].Value == id)
                {
                    element.InnerText = chage;
 
                    xml.Save("Database.xml");
                }
            }
        }
      
