    Guid expectedGuid = ...
    mockIRole.Setup(r => r.GetSomething(
                     It.Is<Guid>(g => g.ToString().StartsWith("4")), 
                     It.Is<Guid>(g => g != Guid.Empty), 
                     It.Is<Guid>(g => g == expectedGuid)))
             .Returns(ReturnSomething);
