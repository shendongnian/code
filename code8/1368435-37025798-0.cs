    Region[] regions = {
                        new Region{
                            Id = 1,
                            Name = "Test 1"
                        },
                        new Region{
                            Id = 3,
                            Name = "Test 3"
                        },
                        new Region{
                            Id = 4,
                            Name = "Test 4"
                        }
                    };
    Mock<IRegionRepo> mock = new Mock<IRegionRepo>();
    mock.Setup(x => x.Region(It.IsAny<int>())).Returns<int>((i) => regions[i]);
    Assert.AreEqual(mock.Object.Region(1), regions[1]);
