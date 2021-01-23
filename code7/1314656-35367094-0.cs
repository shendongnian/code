    [Test]
    public void SomeTestCase()
    {
        ClassUnderTest sut = new ClassUnderTest();
        Func<string, bool> func = (param)=> 
        {
            Assert.That(param, Is.EqualTo("123"));
            return true;//or whatever
        };
    
        sut.Process(func);
    }
