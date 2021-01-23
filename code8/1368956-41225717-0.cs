    var el1 = new Mock<IElementInfo>();
    el1.Setup(x => x.Id).Returns(Guid.NewGuid());
    el1.Setup(x => x.Multiplicity).Returns(Multiplicity.Single);
    var c1 = new Mock<ICollectionInfo>();
    c1.Setup(x => x.Id).Returns(Guid.NewGuid());
    c1.Setup(x => x.Multiplicity).Returns(Multiplicity.Multiple);
    var p1 = new Mock<IPropertyInfo>();
    p1.Setup(x => x.Id).Returns(Guid.NewGuid());
    p1.Setup(x => x.Name).Returns("Foo" + Guid.NewGuid().ToString());
    p1.Setup(x => x.Type).Returns("System.String");
    var p2 = new Mock<IPropertyInfo>();
    p2.Setup(x => x.Id).Returns(Guid.NewGuid());
    p2.Setup(x => x.Name).Returns("Bar" + Guid.NewGuid().ToString());
    p2.Setup(x => x.Type).Returns("System.String");
    var elementInfoMock = new Mock<IElementInfo>();
    elementInfoMock.Setup(e => e.Id).Returns(Guid.NewGuid());
    elementInfoMock.Setup(e => e.Multiplicity).Returns(Multiplicity.Multiple);
    elementInfoMock.Setup(e => e.Elements)
        .Returns(new List<IAbstractElementInfo>
        {
            el1.Object,
            c1.Object,
        });
    elementInfoMock.Setup(x => x.Properties).Returns(
        new List<IPropertyInfo>
        {
            p1.Object,
            p2.Object,
        });
    this.elementInfo = elementInfoMock.Object;
