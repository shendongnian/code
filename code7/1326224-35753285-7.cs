     private void Button_Write_Click(object sender, EventArgs e)
        {
            AccountSettings settings = new AccountSettings();
            settings.Setting1 = this.textBox1.Text;
            settings.Setting2 = this.textBox2.Text;
            settings.Setting3 = this.textBox3.Text;
            settings.CheckboxValue = this.checkBox.Checked;
            WriteJson(settings, SettingsFile);
        }
        private void Button_Read_Click(object sender, EventArgs e)
        {
            AccountSettings settings = ReadJson<AccountSettings>(SettingsFile);
            this.textBox1.Text = settings.Setting1;
            this.textBox2.Text = settings.Setting2;
            this.textBox3.Text = settings.Setting3;
            this.checkBox.Checked = settings.CheckboxValue;
        }
        private static string SettingsFile
        {
            get
            {
                return Path.GetDirectoryName(Application.LocalUserAppDataPath)
               + "\\accounts" + "\\accounts.txt";
            }
        }
        private static void WriteJson(Object obj, string path)
        {
            var ser = new JsonSerializer();
            using (var file = File.CreateText(path))
            using (var writer = new JsonTextWriter(file))
            {
                ser.Serialize(writer, obj);
            }
        }
        private static T ReadJson<T>(string path)
            where T: new()
        {
            if (!File.Exists(path))
                return new T();
            var ser = new JsonSerializer();
            using (var file = File.OpenText(path))
            using (var reader = new JsonTextReader(file))
            {
                return ser.Deserialize<T>(reader);
            }
        }
        private class AccountSettings
        {
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
            public string Setting3 { get; set; }
            public bool CheckboxValue { get; set; }
        }
    }
