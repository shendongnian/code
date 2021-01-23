    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Parse(@"<Students>
                                                      <Student>
                                                        <Name>Josphine</Name>
                                                      </Student>
                                                      <Student>
                                                        <Name>Hendrick</Name>
                                                      </Student>
                                                  </Students>", LoadOptions.SetLineInfo);
                
                IEnumerable<XElement> descendants = doc.Descendants();
    
                foreach (XElement ele in descendants)
                {
                    string ln_num = (((IXmlLineInfo)ele).HasLineInfo() ? ((IXmlLineInfo)ele).LineNumber.ToString() : "");
                    string ln_pos = (((IXmlLineInfo)ele).HasLineInfo() ? ((IXmlLineInfo)ele).LinePosition.ToString() : "");
                    Console.WriteLine(string.Format("{0} ({1}): at line no. {2}, position {3}", ele.Name.ToString(), ele.Value.ToString(), ln_num.ToString(), ln_pos.ToString()));
                }
    
                Console.ReadKey();
            }
        }
    }
