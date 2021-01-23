        [TestMethod]
        public void ConstructorTestForCMAClass()
        {
            // Arrange
            string xmlDocPreState  = "<add name=\"console\" type=\"System.Diagnostics.DefaultTraceCMA\" value=\"Error\"/>";
            string xmlDocPostState = "Whatever...";
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xmlDocPreState);
            XmlAttributeCollection attrColl = doc.DocumentElement.Attributes;
            
            // Act
            CMATracer cMATracer = new CMATracer(attrColl);
            // Assert
            Assert.AreEqual(xmlDocPostState, doc.OuterXml);
        }
