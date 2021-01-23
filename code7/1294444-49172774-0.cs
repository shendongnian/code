            System.Net.ServicePointManager.Expect100Continue = false;
            ServiceReference1.countrySoapClient X = new ServiceReference1.countrySoapClient("countrySoap");
            string Country;
            Country = X.GetCountries();
            XmlDocument AllCountries = new XmlDocument();
            AllCountries.LoadXml(Country);
            XmlNodeList ListOfCountries = AllCountries.SelectNodes("NewDataSet/Table");
            foreach(XmlNode y in ListOfCountries)
            {
                comboBox1.Items.Add(y.InnerText);
            }
        }
