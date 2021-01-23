    [Test]
    public void MyTest
    {
        //arrange
        log4net.ILog log = log4net.LogManager.GetLogger(typeof(MyTestClass));
            log4net.Config.XmlConfigurator.Configure();
            
    }
