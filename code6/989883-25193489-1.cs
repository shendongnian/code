        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void AD_User_Not_Found_Exception()
        {
            var searcher = new Mock<IDirectorySearcher>();
            searcher.Setup(x => x.FindSAMAccountName(It.IsAny<string>()).Throws(new ADException());
            
            var controller = new UsersController(searcher.Object);
            
            try
            {
                SearchResult searchResult = controller.Get("doesn't matter. any argument throws");
            }
            catch (HttpResponseException ex)
            {
                // assert
                Assert.AreEqual(HttpStatusCode.NotFound, ex.Response.StatusCode);
                throw;
            }
        }
