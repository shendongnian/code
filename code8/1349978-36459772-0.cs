        static void Main(string[] args)
        {
            var elementsWithoutB = XDocument.Parse(xml)
                                   .Descendants("Object")
                                   .Where(x => x.Element("B") == null);
            
            // Prove it works by printing the elements returned
            foreach (var element in elementsWithoutB)
            {
                Console.WriteLine(element.ToString());
            }
            Console.Read();
        }
