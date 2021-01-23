        [TestMethod]
        public void TestDomain()
        {
            using (ShimsContext.Create())
            {
                System.DirectoryServices.ActiveDirectory.Fakes.ShimDomain.GetComputerDomain = () =>
                {
                    return new System.DirectoryServices.ActiveDirectory.Fakes.ShimDomain();
                };
                System.DirectoryServices.ActiveDirectory.Fakes.ShimActiveDirectoryPartition.AllInstances.NameGet =
                    partition =>
                    {
                        return "My Name";
                    };
                string curName = System.DirectoryServices.ActiveDirectory.Domain.GetComputerDomain().Name;
                Assert.AreEqual("My Name", curName);
            }
        }
