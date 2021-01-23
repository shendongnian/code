        static void Main(string[] args)
        {
            Contact obj = new Contact();
            var props = obj.GetType().GetProperties();
            foreach (var p in props)
                Console.WriteLine("contact.{0}= null;", p.Name);
            Thread.Sleep(1000);
        }
