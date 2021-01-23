    class Program
    {
        static void Main(string[] args)
        {
            var xdoc =
                XDocument.Load(
                    @"~\Examples\user.xml");
            var users = xdoc.Descendants("userInfo");
            
            // get the specific user
            var user = users.Where(x => x.Element("Passport").Value == "1");
            // get the value from each child element in the selected user 
            foreach(var element in user.Elements())
                {
                Console.WriteLine(element.Value);
            }
            Console.ReadLine();
        }
    }
