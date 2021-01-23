     [TestMethod]
            public void TestLog()
            {
                log4net.Config.XmlConfigurator.Configure();
                ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
                log.Error("test", new Exception("test"));
            }
