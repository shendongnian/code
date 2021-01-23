            String xml = File.ReadAllText("XMLFile1.xml");
            XmlSerializer _Serializer = new XmlSerializer(typeof(ComputerSettingResponse));
            ComputerSettingResponse _ComputerSettingResponse = new ComputerSettingResponse();
            using (StringReader reader = new StringReader(xml))
            {
                _ComputerSettingResponse = (ComputerSettingResponse)_Serializer.Deserialize(reader);
                Debug.WriteLine(_ComputerSettingResponse.Settings.Environment);
            }
