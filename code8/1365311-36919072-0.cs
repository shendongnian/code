        private class Fixture
        {
            public Mock<FooFactory> FooFactoryMock { get; set; } = new Mock<FooFactory>();
            public Sut GetSut()
            {
                return new Sut(FooFactoryMock.Object);
            }
        }
        [Theory]
        [AutoData]
        internal void Foo_IsCorrectlySet_Test(
            [Frozen] Mock<IFooFactory> fooFactory,
            IFoo foo,
            Fixture fixture)
        {
            fixture.FooFactory.Setup(mock => mock.Build(1, 2))
                .Returns(foo)
                .Verifiable();
            var sut = fixture.GetSut();
            var actual = sut.Foo;
            Assert.Equal(foo, sut);
            fooFactory.Verify();
        }
