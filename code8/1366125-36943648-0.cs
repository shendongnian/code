            private void SaveFile()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\Test.xml");
    
                XmlNode Buses = doc.SelectSingleNode("//Buses");
                XmlNode oldPlateNumber = doc.SelectSingleNode("//YES-6548");
    
                XmlElement PlateNumber = doc.CreateElement("DUS-456");
                XmlElement VIN = doc.CreateElement("VIN");
                VIN.InnerText = textBox1.Text;
    
                if (oldPlateNumber != null)
                {
                    Buses.ReplaceChild(PlateNumber, oldPlateNumber);
                    doc.Save("C:\\Test.xml");
                }
                else
                {
                    PlateNumber.AppendChild(VIN);
                    Buses.AppendChild(PlateNumber);
                    doc.Save("C:\\Test.xml");
                }
            }
