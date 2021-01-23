    mock.Verify(x => x.IterateFiles<ICsvConversionProcessParameter, ProcessOutput>(
      It.IsAny<IEnumerable<string>>(),
      It.IsAny<Func<string, ICsvConversionProcessParameter, ProcessOutput>>(),
      It.IsAny<ICsvConversionProcessParameter>(),
      It.IsAny<FileIterationErrorAction>(),
      out outputs), Times.Once);
