        private void CreateNewGUIDIfNotExist()
        {
            string configFilePath = "myAppName.exe.config";
            var doc = new XmlDocument();
            doc.Load(configFilePath);
            var node = doc.SelectSingleNode("//appSettings");
            foreach (XmlNode settingNode in node.SelectNodes("add"))
            {
                if (settingNode.Attributes["key"].Value == "MyGUID")
                {
                    var guidNode = settingNode.Attributes["value"];
                    if (string.IsNullOrEmpty(guidNode.Value))
                        guidNode.Value = System.Guid.NewGuid().ToString();
                    doc.Save(configFilePath);
                    return;
                }
            }
        }
