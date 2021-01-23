    [Test]
    public void Test()
    {
       dynamic ob = new JsonObject();
       ob["test"] = 3;
    
       Assert.That(ob.test, Is.EqualTo(3));
    
    }
