        [TestMethod]
        public void TestMethod1()
        {
            using (Store store = new Store(typeof(EntitiesModel3DomainModel)))
            {
                using (Transaction trans = store.TransactionManager.BeginTransaction())
                {
                    Entity entity = new Entity(store);
                    Assert.IsNotNull(entity);
                }
            }
        }
