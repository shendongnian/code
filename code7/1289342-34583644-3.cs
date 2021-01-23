    private void Form1_Load(object sender, EventArgs e)   
    {
     string SettingsPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Settings.cfg");
     string CustomBackground = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Skins", "Custom", "Background.png");
     string SelectedTheme = System.IO.File.ReadLines(SettingsPath).Skip(7).Take(1).First();
    //LOAD THEME
            if (SelectedTheme.Equals("Default Theme"))
            {
                this.BackgroundImage = Properties.Resources.DefaultBackground;
            }
            else if (SelectedTheme.Equals("Light Theme"))
            {
                this.BackgroundImage = Properties.Resources.LightBackground;
            }
            else if (SelectedTheme.Equals("Custom Theme"))
                this.BackgroundImage = Image.FromFile(CustomBackground);
            else
            {
                this.BackgroundImage = Properties.Resources.DefaultBackground;
            }
    }
