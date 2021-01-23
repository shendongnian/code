    //  these is the namespace of your class
    namespace FYPPrototype1
    {
        // these is the region of your class, where all functions and variables are stored
        public sealed partial class SurveyPage2 : Page
        {
            //  these are local variables
            private NavigationHelper navigationHelper;
            private ObservableDictionary defaultViewModel = new ObservableDictionary();
        
            // this is your class constructor
            public SurveyPage2()
            {
                InitializeComponent();
                this.navigationHelper = new NavigationHelper(this);
                this.navigationHelper.LoadState += navigationHelper_LoadState;
                this.navigationHelper.SaveState += navigationHelper_SaveState;
            }
    .
    .
    .
        }
    }
