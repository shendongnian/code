    public static bool FunEnable(string funNam)
            {
                bool result = true;
                XmlDocument xDL = new XmlDocument();
                xDL.Load(@"C:/XMLFile2.xml"); //Load XML file
                XmlNodeList nodeList = xDL.SelectNodes("//itemb");
                foreach (XmlNode node in nodeList)
                {
                    if (node.Attributes["FunName"].Value.Equals(funNam))
                    {
                        result = Convert.ToBoolean(node.Attributes["isEnable"].Value);
                        break;
                    }
                }
                Console.WriteLine("with funName = "+ funNam +" isEnable equal to : " + result);
                return result;
            }
