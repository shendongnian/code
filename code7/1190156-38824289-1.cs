    [TestMethod]
    public void CodedUITestMethod1()
    {
        ApplicationUnderTest app = ApplicationUnderTest.Launch(@"C:\Users\Dileep\Documents\Visual Studio 2013\Projects\CodedUIDemo\SimpleCalculator\bin\Debug\SimpleCalculator.exe");
    
        WinEdit txtA = new WinEdit(app);
        WinEdit txtB = new WinEdit(app);
        WinEdit txtC = new WinEdit(app);
        WinButton btnAdd = new WinButton(app);
    
        txtA.SearchProperties.Add(WinEdit.PropertyNames.ControlName, "txtA");
        txtB.SearchProperties.Add(WinEdit.PropertyNames.ControlName, "txtB");
        txtC.SearchProperties.Add(WinEdit.PropertyNames.ControlName, "txtC");
        btnAdd.SearchProperties.Add(WinButton.PropertyNames.Name, "btnAdd");
    
        txtA.Text = "50";
        txtB.Text = "50";
        Mouse.Click(btnAdd);
        var result = txtC.GetProperty("Text").ToString();
        Assert.AreEqual("100", result);
    }
