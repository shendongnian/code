    [TestMethod]
    public void PropertyCanChangeWithNoEventHandlersSet() {
        var sut = new SubObservableObject();
        // The next line will throw a null exception with the minimal
        // code written above, since there is no check for 
        // if(null != PropertyChanged) before invoking the PropertyChanged
        // event.
        sut.ChangedProperty = "newValue";
        Assert.AreEqual("newValue", sut.ChangedProperty);
    }
