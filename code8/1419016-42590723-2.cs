    class YourPageObject
    {
        public YourPageObject()
        {
            PageFactory.InitElements(TestBase.ngWebDriver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "a[ng-click='addNewTrack()']")]
        public IWebElement BtnAddNewTrack { get; set; }
        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByModelFinder), Using = "trackSearch")]
        public IWebElement TxtSearchTrack { get; set; }
        [FindsBy(How = How.Custom, CustomFinderType = typeof(NgByRepeaterFinder), Using = "track in models.tracks | filter: trackSearch")]
        public IList<IWebElement> BtnListTracks { get; set; }
    } 
