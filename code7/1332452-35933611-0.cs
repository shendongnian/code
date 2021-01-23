    private int TestCaseCycle;
    public int TestCaseCycle_Value
    {
        get { return TestCaseCycle; }
        set { TestCaseCycle = value; }
    }
    public string TestCaseCycle_Text // just a read only property
    {
        get 
        {
            ddlTestCycle.Items.FindByValue(TestCaseCycle);
        }
    }
