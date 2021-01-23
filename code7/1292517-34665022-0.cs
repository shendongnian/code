    public class OptionsForm : Form
    {
        private static OptionsForm _instance;
        public static OptionsForm Options
        {
            get
            {
                if (_instance == null) _instance = new OptionsForm();
                return _instance;
            }
        }
        
        private int ActualLevel; //variable to hold the level to "go back to/retry"
        public void ShowOptions(int actualLevel)
        {
            ActualLevel = actualLevel;
            //do any processing required
            Show(); // or ShowDialog(); depending on your needs
        }
    }
