        private void DEFAULTTHEME_Click(object sender, EventArgs e)
        {            
            string SettingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Settings.cfg");            
            string SelectedTheme = "Default Theme"; //THIS GETS WRITTEN TO THE SETTINGS FILE           
            var lines = System.IO.File.ReadAllLines(SettingsPath);
            lines[7] = (SelectedTheme);
            System.IO.File.WriteAllLines(SettingsPath, lines);
            MainForm.BackgroundImage = Properties.Resources.DefaultBackground;
        }
        private void LIGHTTHEME_Click(object sender, EventArgs e)
        {            
            string SettingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Settings.cfg");            
            string SelectedTheme = "Light Theme"; //THIS GETS WRITTEN TO THE SETTINGS FILE           
            var lines = System.IO.File.ReadAllLines(SettingsPath);
            lines[7] = (SelectedTheme);
            System.IO.File.WriteAllLines(SettingsPath, lines);
            MainForm.BackgroundImage = Properties.Resources.LightBackground;
        }
        private void CUSTOMTHEME_Click(object sender, EventArgs e)
        {
            string SettingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Settings.cfg");
            string CustomBackground = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Skins", "Custom", "Background.png"); //THIS IS SO MY APPLICATION KNOWS THE LOCATION OF THE CUSTOM BACKGROUND IMAGE
            string SelectedTheme = "Custom Theme"; //THIS GETS WRITTEN TO THE SETTINGS FILE
            var lines = System.IO.File.ReadAllLines(SettingsPath);
            lines[7] = (SelectedTheme);
            System.IO.File.WriteAllLines(SettingsPath, lines);
            MainForm.BackgroundImage = Image.FromFile(CustomBackground);
        }
  
