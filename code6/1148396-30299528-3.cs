    [Test]
    public void TestSomeStuff() {
        var em = new Mock<IEntityManagerWrapper>();
        var pe = new Mock<PersonaEntityManager>();
        pe.Setup(x => x.UpdatePersona(It.IsAny<PersonaUpdateRequestData>())).Returns(new PersonaResponseData());
        em.Setup(x=>x.GetEntityManager<PersonaEntityManager>(It.IsAny<EntityManager.EntityManagerInstanceType>())).Returns(pe.Object);
        var sut = new MyProductionCode(em.Object);
        sut.DoStuff();
    }
