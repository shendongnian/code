        public string EditDoc()
        {
            string filename = "Path/MyFileName.xml";
            List<string> list = new List<string>();
            if (File.Exists(filename)) //we have the file, so update it
            {
                XmlDocument myDoc = new XmlDocument(); //create a document object
                myDoc.Load(filename); //load existing info
                XmlNode root = myDoc.DocumentElement; //the root node ("Country")
                XmlNode nodeToUpdate = root.SelectSingleNode("CountryName"); //select the node to update
                nodeToUpdate.Value = "new info"; //give it a new value
                myDoc.Save(filename); //save the document
            } 
            else //didn't find the file
            {
                XmlDocument myDoc = new XmlDocument(); //create a new document
                XmlNode country = myDoc.CreateElement("Country"); //create the parent "Country" element
                myDoc.AppendChild(country); //append it to the document
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNode countryName = myDoc.CreateElement("CountryName"); //create element for "CountryName"
                    countryName.AppendChild(myDoc.CreateTextNode(list[i].CountryName)); //add data from list index
                    country.AppendChild(countryName); //append this as a child to "Country"
                    XmlNode countryUserAddress = myDoc.CreateElement("CountryUserAddress"); //create element for "CountryUserAddress"
                    countryUserAddress.AppendChild(myDoc.CreateTextNode(list[i].CountryUserAddress)); //add data from list index
                    country.AppendChild(countryUserAddress); //append as a child to "Country"
                }
                myDoc.Save(filename); //save the document
            }
        }
