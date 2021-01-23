        private void Button_Write_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.Setting1 = this.textBox1.Text;
            settings.Setting2 = this.textBox2.Text;
            settings.Setting3 = this.textBox3.Text;
            settings.CheckboxValue = this.checkBox.Checked;
            WriteJsonSettings(settings);
        }
        private void Button_Read_Click(object sender, EventArgs e)
        {
            Settings settings = Form1.ReadJsonSettings();
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
        private static void WriteJsonSettings(Settings settings)
        {
            var ser = new JsonSerializer();
            using (var file = File.CreateText(SettingsFile))
            using (var writer = new JsonTextWriter(file))
            {
                ser.Serialize(writer, settings);
            }
        }
        private static Settings ReadJsonSettings()
        {
            if (!File.Exists(SettingsFile))
                return new Settings();
            var ser = new JsonSerializer();
            using (var file = File.OpenText(SettingsFile))
            using (var reader = new JsonTextReader(file))
            {
                return ser.Deserialize<Settings>(reader);
            }
        }
        private class Settings
        {
            public string Setting1 { get; set; }
            public string Setting2 { get; set; }
            public string Setting3 { get; set; }
            public bool CheckboxValue { get; set; }
        }
