    class Program
    {
        static void Main(string[] args)
        {
            var xdoc =
                XDocument.Load(
                    @"~\Examples\user.xml");
            var users = xdoc.Descendants("userInfo");
            var user = users.Where(x => x.Element("Passport").Value == "1");
            foreach(var element in user.Elements())
                {
                Console.WriteLine(element.Value);
            }
            Console.ReadLine();
        }
    }
