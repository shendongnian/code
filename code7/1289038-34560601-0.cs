    using System.IO;
    private void ChangeBGButton_Click(object sender, EventArgs e)
    {  
        string BackgroundSkinsPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Skins", "Skin.cfg");
        string currentBackgroundImage = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments), "Application Name", "Skins", "Background2.png");
        File.WriteAllText(BackgroundSkinsPath, currentBackgroundImage );
        this.BackgroundImage = Image.FromFile(File.ReadAllText(currentBackgroundImage));
    }
