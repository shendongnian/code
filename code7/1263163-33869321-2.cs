    [Test]
    public void MultiFail(){
    var context = new QContext{AvailFail=2};
	QAssert.False(true, context); //AvailFail=1
	QAssert.True(false, context); //AvailFail=2
	QAssert.True(true, context);
    }
