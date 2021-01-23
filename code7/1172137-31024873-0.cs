     Configuration myConfiguration = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
      myConfiguration.AppSettings.Settings.Item("myKey").Value = txtmyKey.Text;
      myConfiguration.AppSettings.Settings.Remove("MyVariable");
      myConfiguration.AppSettings.Settings.Add("MyVariable", "MyValue");
      myConfiguration.Save();
