    [Test]
    public void Test() {
        MyMessageBox messageBox = Substitute.For<MyMessageBox>();
        messageBox.Show("Sure?", "Title", MessageBoxButtons.YesNo).Returns(DialogResult.Yes);
    
        Abc abc = new Abc(messageBox);
        abc.MyMethod();
    
        Assert.AreEqual(1, abc.a);
    }
