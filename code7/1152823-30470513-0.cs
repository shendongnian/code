    [TestMethod]        
    public void TestMyConfigurationUsedToReadConfiguration()
    {            
        MyConfiguration calledOnInstance = null;     
        MyConfiguration returnedInstance = null;
        XmlNode calledWithSection = null;
        XmlNode sectionIn = null;
        using (ShimsContext.Create())
        {
            ShimMyConfiguration.Constructor = @this => new ShimMyConfiguration()
            {
                return;
            };
            ShimMyConfiguration.AllInstances.LoadValuesFromConfigXmlNode = (a,b) =>
            {
                calledOnInstance = a;
                calledWithSection = b;
                return;
            };
            var _MyConfigurationHandler = new MyConfigurationHandler();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml("<Common.Mys><Mys><add name=\"LoggingErrorMessage\"/><remove name=\"LoggingMessageBox\"/></Mys></Common.Mys>");          
            sectionIn = xmlDoc.SelectSingleNode("Common.Mys");
            returnedInstance = _MyConfigurationHandler.Create(null, null, sectionIn);                 
       
        }           
        Assert.IsNotNull(returnedInstance);
        Assert.AreEqual(returnedInstance, calledOnInstance);
        Assert.AreEqual(sectionIn, calledWithSection);
    }
