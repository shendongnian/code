    private ActionsMap actionTest;
    [TestInitialize]
    public void Setup()
    {
      actionTest = new ActionsMap();
    }
    [TestMethod]
    public void can_open()
    {
      actionTest.ActionsOpen();
      //asserts?
    }
    [TestMethod]
    public void can_remove_header_columns()
    {
      actionTest.ActionsOpen(); //assuming next method depends on this
      actionTest.Actions_header_remove_colls();
      //asserts?
    }
    [TestMethod]
    public void can_insert_header_column()
    {
      actionTest.ActionsOpen(); //assuming next method depends on this
      actionTest.Actions_header_remove_colls(); //assuming next method depends on this
      actionTest.Actions_click_insert_header();
      //asserts?
    }
