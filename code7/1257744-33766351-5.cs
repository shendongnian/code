     {
            // 1. Open the settings xml file present in the same location
            string settingName = "Lables2.SETTINGS";  // Setting file name
            XmlDocument docSetting = new XmlDocument();
            docSetting.Load(Application.StartupPath + Path.DirectorySeparatorChar + settingName);
            XmlNodeList labelSettings = docSetting.GetElementsByTagName("Settings")[0].ChildNodes;
            Console.WriteLine("Code {0} Group{1} Name{2}", Lables.Default.Code, Lables.Default.Group, Lables.Default.Name); //prints Code A1 GroupB1 NameC1
            //2. look for all Lables2 settings in Label settings & update
             foreach (XmlNode item in labelSettings)
             {
                 var nameItem = item.Attributes["Name"];
                 Lables.Default.PropertyValues[nameItem.Value].PropertyValue = item.InnerText;                
             }
             Lables.Default.Save(); // save. this will save it to user.config not app.config but the setting will come in effect in application
             Lables.Default.Reload();
             Console.WriteLine("Code {0} Group{1} Name{2}", Lables.Default.Code, Lables.Default.Group, Lables.Default.Name); //prints Code A2 GroupB2 NameC2
        }
