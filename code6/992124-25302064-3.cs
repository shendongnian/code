    [TestFixture]
    public void ATests
    {
        [Test]
        public void MethodA_DoesSomethingImportant()
        {
            var testedComponent = new TestableA();
            testedComponent.TestableMethodA();
            // verify 
        }
    }
