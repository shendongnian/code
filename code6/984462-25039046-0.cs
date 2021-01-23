        [TestMethod]
        public void CreateNewScan()
        {
            HomeController controller = new HomeController();
            ClientGroup clientGroup = new ClientGroup(){ 
                //some property initializers
            };
            JsonResult result = controller.CreateNewScan(clientGroup, new Version(1, 0));
            dynamic data = result.Data;
            Assert.IsTrue(data.Success);
        }
