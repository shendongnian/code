    public partial class App : Application
    {
        Dictionary<string, string> localizer;
        public App()
        {
            localizer = new Dictionary<string, string>() { { "loc", "locdsasdasd" } };
            //LoadLocalizer(); 
            this.Resources.Add("Localizer", localizer);
        }
    }
