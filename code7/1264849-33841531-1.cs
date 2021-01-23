	var log = Substitute.For<ILog>();
	var loggedErrors = new List<string>();
	// Capture the argument passed to Log whenever LogLevel.Error is called
	log.Log (LogLevel.Error, Arg.Do<Func<string>>(x => loggedErrors.Add(x())));
	log.Log(LogLevel.Error, () => "the real call...");
	Assert.That(loggedErrors, Is.EqualTo (new[] { "expected" }));
    /*
    NUnit.Framework.AssertionException:   Expected is <System.String[1]>, actual is <System.Collections.Generic.List`1[System.String]> with 1 elements
      Values differ at index [0]
      Expected string length 8 but was 16. Strings differ at index 0.
      Expected: "expected"
      But was:  "the real call..."
      -----------^
    */
