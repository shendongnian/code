    foreach (var fname in firstNamePossibleValues) {
        foreach (var lname in lastNamePossibleValues) {
            var testObject = new SomeEntity {
               Id = 1, // this must be always 1 for this test
               FirstName = fname, // each of this values must be accepted in test
               LastName = lname // each of this values must be accepted in test
            }
            var result = someOtherObject.DoSomething(testObject);
            Assert.AreEqual("some expectation", result);
        }
    }
    
