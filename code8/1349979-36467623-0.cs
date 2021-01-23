    static void Main(string[] args)
            {
                XElement objects = XElement.Parse(@"<Objects>
                                                      <Object>
                                                        <ID>1</ID>
                                                        <A>1</A>
                                                        <B>1</B>
                                                        <C>1</C>
                                                      </Object>
                                                      <Object>
                                                        <ID>2</ID>
                                                        <A>2</A>
                                                        <B>2</B>
                                                        <C>2</C>
                                                      </Object>
                                                      <Object>
                                                        <ID>3</ID>
                                                        <A>3</A>
                                                        <C>3</C>
                                                      </Object>
                                                      <Object>
                                                        <ID>4</ID>
                                                        <A>4</A>
                                                        <B/>
                                                        <C>4</C>
                                                      </Object>
                                                    </Objects>");
                
                string xpath_string = "//Object[count(B) = 0]"; //you can change the name of the element anytime,
                                                                //even in the run-time also... just make sure
                                                                //to add `System.Xml.XPath` to utilize the XPath...
                IEnumerable<XElement> query_for_objects = objects.XPathSelectElements(xpath_string);
                foreach (XElement ele in query_for_objects)
                {
                    Console.WriteLine(ele.ToString());
                }
                Console.ReadKey();
