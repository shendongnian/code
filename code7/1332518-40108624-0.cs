    [FindsBy(How = How.Id, Using = "someId")]
    private IList<IWebElement btnTitleView { get; set; }
    ...
    Actions action = new Actions(Browser.driver);
    action.MoveToElement(btnTitleView.First()).Perform();
