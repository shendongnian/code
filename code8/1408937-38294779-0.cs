    //using System.Xml.Linq;
            XElement cities = XElement.Load("fileName");
            List<string> list = new List<string>();
            
            foreach (var city in cities.Elements("City"))
            {
                StringBuilder cityInfo = new StringBuilder();
                cityInfo.Append(city.Attribute("name").Value + ",");
                cityInfo.Append(city.Attribute("no").Value + ",");
                foreach (var district in city.Elements("District"))
                {
                    cityInfo.Append(district.Attribute("name").Value + ",");
                    foreach (var zip in district.Elements("Zip"))
                    {
                        cityInfo.Append(zip.Attribute("code").Value + ",");
                    }
                }
                list.Add(cityInfo.ToString());
                cityInfo.Clear();
            }
            //do what you want with list
