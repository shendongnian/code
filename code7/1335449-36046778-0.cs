    [TestMethod]
    public void WhenClearingTextOnAControl_AndControlContainsNestedCheckboxes_ShouldClearCheckedBoxes()
    {
        // arrange: create a control hierarchy
        var input = new Panel();
        var insidePanel = new Panel();
        var checkbox = new Checkbox();
        input.Controls.Add(insidePanel);
        insidePanel.Controls.Add(checkbox);
        checkbox.Checked = true;
        
        // act: invoke our function
        _subject.ClearText(input);
   
        // assert
        Assert.IsFalse(checkbox.Checked, "Inner checkbox should have been cleared.");
    }
