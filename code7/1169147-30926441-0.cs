      List<City> cityList = new List<City>();
                string url ="/App_Data/Countries.xml";
                XmlDocument doc = new XmlDocument();
                doc.Load(Server.MapPath(url));
                XmlNodeList nodeList = doc.SelectNodes("//Country");
                foreach(XmlNode node in nodeList){
                    if (node != null)
                    {                        
                        int id = int.Parse(node.ChildNodes.Item(0).InnerText);
                        string name = node.ChildNodes.Item(1).InnerText;
                        City city = new City(id,name);
                        cityList.Add(city);
                    }
                }
