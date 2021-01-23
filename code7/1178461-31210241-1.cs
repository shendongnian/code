    public void WhenRowIsCreatedItShouldBeInAnUnchangedState()
    {
      var row = new PocoTest(); // Derived from aforementionned base class
      Assert.AreEqual(RecordStates.Unchanged, row.RecordState);
      Assert.IsFalse(row.IsPropertyModified("MyProperty"));
    }
    public void WhenPropertyIsChangedItShouldBeInAModifiedState()
    {
      var row = new PocoTest(); // Derived from aforementionned base class
      row.MyProperty = "this is a new value";
      Assert.AreEqual(RecordStates.Modified, row.RecordState);
      Assert.IsTrue(row.IsPropertyModified("MyProperty"));
    }
    public void WhenChangesAreAcceptedItShouldBeInAnUnchangedState()
    {
      var row = new PocoTest(); // Derived from aforementionned base class
      row.MyProperty = "this is a new value";
      row.AcceptChanges();
      Assert.AreEqual(RecordStates.Unchanged, row.RecordState);
      Assert.IsFalse(row.IsPropertyModified("MyProperty"));
    }
