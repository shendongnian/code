    TestClass testing = new TestClass();
	var prop = typeof(TestClass).GetProperty("testDate1");
    // Here we get the current value of testing.testDate1, which is the default DateTime.MinValue
	object o = prop.GetValue(testing);
    // Here we set o to null... has ZERO effect on testing.testDate1. 
	o = null;
    // What you actually want is probably the following.
    // (Remember though that testDate1 can't be null... this just sets it back to DateTime.MinValue.)
    prop.SetValue(testing, null);
