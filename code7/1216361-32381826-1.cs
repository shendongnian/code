    [FindsBy(How = How.Id, Using = "ngp_total_records")]
    private IWebElement txtNGPTotalRecords { get; set; }
    [FindsBy(How = How.Id, Using = "ngp_usi_total_records")]
    private IWebElement txtNGPUSITotalRecords { get; set; }
    // no FindsBy here... this gets set in its getter
    public IWebElement txtTotalRecords;
