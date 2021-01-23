    // Writing / Modifying app setting value
                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
                webConfigApp.AppSettings.Settings["datasource"].Value = TextBox1.Text;
                webConfigApp.AppSettings.Settings["initialcatalog"].Value = TextBox2.Text;
                webConfigApp.AppSettings.Settings["userid"].Value = TextBox3.Text;
               
                // Encrypt password in app setting
                TextBox4.Text = Convert.ToBase64String(Encoding.Unicode.GetBytes(TextBox4.Text));
                webConfigApp.AppSettings.Settings["password"].Value = TextBox4.Text;
                webConfigApp.Save();
