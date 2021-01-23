    [Serializable]
    public class FormSettings
    {
        public FormWindowState WindowState { get; set; }
        public Size Size { get; set; }
        public Point Location { get; set; }
    }
    public static class FormExtensions
    {
        private const String FolderName = "MyApplication";
        private const String PreferenceFileName = "FormSettings.xml";
        public static void LoadSettings(this Form form)
        {
            String myAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FolderName);
            String formSettingFilePath = Path.Combine(assetCaptureFolderPath, PreferenceFileName);
            if (File.Exists(formSettingFilePath))
            {
                using (var sr = new StreamReader(formSettingFilePath))
                {
                    XmlSerializer xmlser = new XmlSerializer(typeof(FormSettings));
                    var formSettings = (FormSettings)xmlser.Deserialize(sr);
                    if (formSettings != null)
                    {
                        form.Size = formSettings.Size;
                        form.Location = formSettings.Location;
                        form.WindowState = formSettings.WindowState;
                    }
                }
            }
        }
        public static void SaveSettings(this Form form)
        {
            FormSettings formSettings = new FormSettings();
            formSettings.WindowState = form.WindowState;
            if (form.WindowState == FormWindowState.Normal)
            {
                formSettings.Size = form.Size;
                formSettings.Location = form.Location;
            }
            else
            {
                formSettings.Size = form.RestoreBounds.Size;
                formSettings.Location = form.RestoreBounds.Location;
            }
            String myAppFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), FolderName);
            String formSettingFilePath = Path.Combine(assetCaptureFolderPath, PreferenceFileName);
            using (var sw = new StreamWriter(formSettingFilePath))
            {
                XmlSerializer xmlSer = new XmlSerializer(typeof(FormSettings));
                xmlSer.Serialize(sw, formSettings);
            }
        }
