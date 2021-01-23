    protected void EditConfigButton(object sender, EventArgs e)
    {
       Configuration objConfig = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~");
       AppSettingsSection objAppsettings = (AppSettingsSection)objConfig.GetSection("appSettings");
       //Edit
       if (objAppsettings != null)
       {
          objAppsettings.Settings["test"].Value = "newvalueFromCode";
          objConfig.Save();
       }
    }
