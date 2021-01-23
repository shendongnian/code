        [TestMethod]
        public void TestContainer()
        {
            IUnityContainer container = new UnityContainer().LoadConfiguration();
            foreach (var registration in container.Registrations)
            {
                Assert.IsNotNull(container.Resolve(registration.RegisteredType, registration.Name));
            }
        }
