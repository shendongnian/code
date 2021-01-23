                XDocument doc = XDocument.Load("Users.xml");
                Console.WriteLine(doc.Descendants("users").Descendants().Count());
                foreach (XElement u in doc.Descendants("users").Descendants())
                {
                    Console.WriteLine("value of the attribute is " + u.Attributes("access").First().Value);
                }
              
