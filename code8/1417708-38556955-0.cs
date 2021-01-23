    _mockRepository
    .Setup(r => r.Add(It.IsAny<Comment>()))
    .Callback(c => _service.Add(c));
    _mockRepository
    .Setup(r => r.GetAll())
    .Returns(_service.GetAll());
