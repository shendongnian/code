    [Test]
    [ExpectedException( typeof( UnauthorizedAccessException) )]
    public void TestExceptionIsRaised()
    {
            var ex = Assert.Throws<UnauthorizedAccessException>(() => TestExceptionMethod());
            StringAssert.Contains("Attempted to perform an unauthorized operation", ex.Message);
    }
