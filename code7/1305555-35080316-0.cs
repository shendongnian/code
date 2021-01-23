            bool isCorrectParam = false;
            IWebService serviceMock = MockRepository.GenerateMock<IWebService>();
              serviceMock.Expect(x => x.CopyFile(null))
                  .IgnoreArguments()
                  .WhenCalled(x =>
                  {
                      Request req = x.Arguments[0] as Request;
                      if (req.Data.Count() == 0 && req.Filename == null)
                      {
                          isCorrectParam = true;
                      }
                  });
            Service service = new Service(serviceMock);
            service.CopyFile(null, new byte[] { });
            Assert.IsTrue(isCorrectParam);
