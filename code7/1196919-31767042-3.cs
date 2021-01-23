        static void Main(string[] args)
        {
            string dataXML1 = "<Root><!-- This is first XML -->    <data><NUMBER>1</NUMBER><NAME>Monkey</NAME><PRICE>1240</PRICE>    </data><data><NUMBER>2</NUMBER><NAME>Tiger</NAME><PRICE>2500</PRICE>    </data><data><NUMBER>3</NUMBER><NAME>Elephant</NAME><PRICE>4810</PRICE>    </data><data><NUMBER>4</NUMBER><NAME>Zebra</NAME><PRICE>5600</PRICE>    </data></Root>";
            string dataXML2 = "<Root><!-- This is second XML --><data>    <NUMBER>1</NUMBER>    <NAME>Gorilla</NAME>    <PRICE>1240</PRICE>  </data>  <data>    <NUMBER>2</NUMBER>    <NAME>Bengal</NAME>    <PRICE>2500</PRICE></data>    </Root>";
            XDocument doc = XDocument.Parse(dataXML1);
            XDocument doc2 = XDocument.Parse(dataXML2);
            
            Dictionary<string, myXMLAnimals> dataDictionary = new Dictionary<string, myXMLAnimals>();
            List<XDocument> myXMLDocumentsToCompare = new List<XDocument>();
            myXMLDocumentsToCompare.Add(doc);
            myXMLDocumentsToCompare.Add(doc2);
            //You can add more documents if you need to!
            foreach (XDocument documento in myXMLDocumentsToCompare)
            {
                Console.WriteLine("New Document!");
                string lastKey = "";
                //I assume that you only have 3 elements per object, number, name and price, you have to addapt it as you need.
                foreach (XElement element in documento.Descendants().Where(p => p.HasElements == false))
                {
                    string keyName = element.Name.LocalName;
                    Console.WriteLine("> lastKey = " + lastKey);
                    if (keyName.Equals("NUMBER"))
                    {
                        lastKey = element.Value;
                        Console.WriteLine("New element!:" + lastKey);
                        if (!dataDictionary.ContainsKey(lastKey))
                        {
                            dataDictionary.Add(lastKey, new myXMLAnimals(element.Value));
                        }
                    }
                    else if (keyName.Equals("NAME")) // remove this if if you dontwant to replace the NAME
                    {
                        dataDictionary[lastKey].NAME = element.Value;
                    }
                    else if (keyName.Equals("PRICE")) // remove this if if you dontwant to replace the price
                    {
                        dataDictionary[lastKey].price = element.Value;
                    }
                    Console.WriteLine(keyName + " = " + element.Value);
                }
            }
            
            Console.WriteLine("THIS IS THE RESULT:");
            foreach (KeyValuePair<string, myXMLAnimals> pair in dataDictionary)
            {
                Console.WriteLine(pair.Key + " = " + pair.Value.NAME+", Price:" + pair.Value.price);
            }
           Console.Beep();
            Console.ReadKey();
        }
