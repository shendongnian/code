    [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void UniqueObjectTest()
            {
                var provider = new RemoteUniqueIdsProvider();
    
                var factory = new UniqueObjectsFactory<MyObjects>(provider);
    
                var entity = factory.GetNewEntity();
                var entity2 = factory.GetNewEntity();
    
                Assert.AreNotEqual(entity.UniqueId, entity2.UniqueId);
    
    
            }
        
        }
