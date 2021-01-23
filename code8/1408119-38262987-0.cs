    public void Test1() {
      var isMorning = true;
      var result = isMorning ? "Morning" : "Afternoon";
      Assert.AreEqual("Morning", result);
    }
    
    public void Test2() {
      var isMorning = false;
      var result = isMorning ? "Morning" : "Afternoon";
      Assert.AreEqual("Afternoon", result);
    }
