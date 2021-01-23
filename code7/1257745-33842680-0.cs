     XmlDocument doc = new XmlDocument();
            //doc.Load(@"C:\Users\***\Documents\Visual Studio 2008\Projects\ChangingLablesRuntime\ChangingLablesRuntime\_Labels2.settings");
            //doc.Save(@"C:\Users\SHYAZDI.IDEALSYSTEM\Documents\Visual Studio 2008\Projects\ChangingLablesRuntime\ChangingLablesRuntime\_Labels.settings");
            doc.Load(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
            var root = doc.GetElementsByTagName("userSettings")[0];
            doc.GetElementsByTagName("userSettings")[0].SelectSingleNode("Zeus._Labels").InnerText = doc.GetElementsByTagName("userSettings")[0].SelectSingleNode("ChangingLablesRuntime._Labels2").InnerText;
          
          
            //var newEml = root.SelectSingleNode("ChangingLablesRuntime._Labels2");
            //var oldEml = root.SelectSingleNode("Zeus._Labels");
            //oldEml.InnerText = newEml.InnerText;
            //oldEml.ParentNode.ReplaceChild(newEml, oldEml);
            doc.Save(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);
         
