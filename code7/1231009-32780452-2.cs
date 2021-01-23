        private void Add_Click(object sender, EventArgs e)
        {
            List<Serialization> list = new List<Serialization>();
            if (File.Exists(xmlPath))
            {
                list = XMLDeserialize();
                Serialization obj = new Serialization() { ID = "NewData", APIKEY = "NewAPIKey", VCODE = "NewVCode" };
                list.Add(obj);
                UpdateXMLSerialize(list);              
            }
        }
