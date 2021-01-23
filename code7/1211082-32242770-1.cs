            [TestMethod]
            public async Task RequestParametersIsNotNullTest()
            {
                Dictionary<string, string> parameters = new Dictionary<string, string>();
                await ThreadHelper.ExecuteOnUIThread(() =>
                {
                   exampleObject.MethodThatReturnsDictionary();
                });
                Assert.IsNotNull(parameters);
            }
