            XDocument xDoc = new XDocument();  
            while ((line = sr.ReadLine()) != null)
            {
                string[] nodes = line.Split('_');               
                for (int j = 0; j < nodes.Length; j++)
			    {
			        if(j == 0) // assume that all line should start with same root name
                    {
                        if (xDoc.Root == null)
                        {
                            var root = new XElement(nodes[j]);
                            xDoc.Add(root);
                        }
                    }
                    else
                    {
                        var previousNode = xDoc.Descendants(nodes[j - 1]).FirstOrDefault();
                        if (nodes[j].Contains('='))
                        {
                            var elementValues = nodes[j].Split('=');
                            if (previousNode.DescendantNodes().Count() == 1 && previousNode.Value != "")
                            {
                                previousNode.AddAfterSelf(new XElement(nodes[j - 1], new XElement(elementValues[0], elementValues[1])));                                    
                            }
                            else
                            {
                                previousNode.Add(new XElement(elementValues[0], elementValues[1]));
                            }
                        }
                        else
                        {
                            var node = xDoc.Descendants(nodes[j]);                            
                            if (node.Count() == 0)
                            {
                                previousNode.Add(new XElement(nodes[j]));
                            }
                        }
                    }
			    }
