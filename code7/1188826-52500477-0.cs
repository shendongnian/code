    whitelistRepositoryMock.Setup(w => w.GetByTypeValue(It.IsAny<WhitelistType>(), It.IsAny<string>()))
                                    .ReturnsAsync((WhitelistType type, string value) =>
                                    {
                                        return (from  item in whitelist
                                                where item.Type == type && item.Value == value
                                                select item).FirstOrDefault();
                                    });
