    [TestClass]
    public class ObservableObjectTests {
        [TestMethod]
        public void PropertyChangedEventHandlerIsRaised() {
            // Create the object to test (sut)
            var sut = new SubObservableObject();
            //  Create a flag to monitor if event handler has fired
            //  set it to false initially, since it hasn't...
            bool raised = false;
            // Register our test event handler, with the PropertyChanged
            // event.
            sut.PropertyChanged += (Sender, e) => {
                    // Check that when the event handler is called
                    // it is for the 'ChangedProperty'
                    Assert.IsTrue(e.PropertyName == "ChangedProperty");
                    // Set our flag to indicate that event was triggered
                    raised = true;
                };
             
            // Actually perform the test, by setting 'ChangedProperty' to 
            // a new value.  This will fire the code above if it works.
            sut.ChangedProperty = "newValue";
            // Validate that our raised flag has been set to true, indicating
            // that our test event handler was triggered.
            Assert.AreEqual(true, raised);
        }
    }
