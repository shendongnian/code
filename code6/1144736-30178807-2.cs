    var mockHelper = new Mock<IViewHelper>();
            mockHelper.Setup(
                x =>
                    x.SerializeView(It.IsAny<ControllerContext>(), It.IsAny<ViewDataDictionary>(),
                        It.IsAny<TempDataDictionary>(), "", It.IsAny<PublicPortalViewModel>())).Returns("<html></html>");
            var sut = new HomeController(mockService, mockHelper.Object);
            var fakePublicPortalViewModel = new PublicPortalViewModel{RequestNumber = "23"};
            bool captchaValid = true;
            var result = sut.Index(fakePublicPortalViewModel, captchaValid) as JsonResult;
            dynamic jsonObject = result.Data;
