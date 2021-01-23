    [Test]
    [ExpectedException(typeof(CustomException), ExpectedMessage = "Oh nozzzz!")]
    public void SomeTest2()
    {
        p.SomeMethod();
    }
