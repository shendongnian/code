    internal static class ApplicationSettings
    {
        //added public static because I didn't see how you planned on invoking save
        public static void Save(int no, string value)
        {
            //sets the nameX
            Properties.Settings.Default["name"+no.ToString()] = value;
            //save the settings
            Properties.Settings.Default.Save();
        }
    }
