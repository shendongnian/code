    var fakeMenuRepository = new Mock<IMenuItemRepository>();
    fakeMenuRepository.Setup(repository => repository.GetAll())
                      .Returns(new List<MenuItem>()
                      {
                          new MenuItem() { Text = "uu" },
                          new MenuItem() { Text = "zz" }
                      });
    var fakeLocator = new Mock<IProcessorLocator>();
    fakeLocator.Setup(locator => locator.GetProcessor<IMenuItemRepository>())
               .Returns(fakeMenuRepository.Object);
    var target = new MainNavigationViewComponent(fakeLocator.Object);
