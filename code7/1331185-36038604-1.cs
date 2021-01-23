     [TestMethod, Isolated]
     public void TestGet()
     {
         var target = new ClassUnderTest();
         var returnMock = Isolate.Fake.Instance<IFindFluent<Location, Location>>();
    
         int size = 3;
    
         Isolate.WhenCalled(() => returnMock.Count()).WillReturn(size);
         Isolate.WhenCalled(() => target.GetFluent(default(Expression<Func<Location, bool>>))).WillReturn(returnMock);
    
         Assert.AreEqual(size, target.GetFluent<Location>(location => true).Count());
    }
