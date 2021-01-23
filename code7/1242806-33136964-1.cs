    [TestMethod] public void Pass() {
        int x = 4;
        x = Increment(x);
       Assert.AreEqual(5, x);
     }
    int Increment(int num) {return ++num; }
