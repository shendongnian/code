     XElement rootBook = XElement.Load("try.xml");
            IEnumerable<XElement> Book =
                from el in rootBook.Descendants("BibUnstructured").ToList()
                select el;
            foreach (XElement el in Book)
            {
                if (!el.HasElements)
                {
                    XElement parent= el.Parent;
                    string value=el.Value;
                    el.Remove();
                    parent.Value=value;
                    Console.WriteLine(parent);
                }
           
            }
            Console.WriteLine(rootBook.ToString());
