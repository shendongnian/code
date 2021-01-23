            {
                // 1. Open the settings xml file present in the same location
                string settingName = "Lables2.SETTINGS";  // Setting file name
                XmlDocument docSetting = new XmlDocument();
                docSetting.Load(Application.StartupPath + Path.DirectorySeparatorChar + settingName);
                XmlNodeList labelSettings = docSetting.GetElementsByTagName("Settings")[0].ChildNodes;
                // 2. Open the config file 
                string configFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
                XmlDocument appSettingDoc = new XmlDocument();
                appSettingDoc.Load(configFile);
                XmlNodeList appConfigLabelSettings = appSettingDoc.GetElementsByTagName("userSettings")[0].
                    SelectNodes("WindowsFormsApplication2.Lables")[0].ChildNodes;
                //ProjectName.Setting file
                //3. update the config file 
                for (int i = 0; i < appConfigLabelSettings.Count; i++)
                {
                    var v = appConfigLabelSettings.Item(i).ChildNodes[0];
                    v.InnerText = labelSettings.Item(i).InnerText;
                }
                //4. save & load the settings 
                appSettingDoc.Save(configFile);
                Lables.Default.Reload();
                MessageBox.Show(Lables.Default.Code); // test pass... shows A2
            }
