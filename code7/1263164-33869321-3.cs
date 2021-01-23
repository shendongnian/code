	[Test]
	[QContext(AvailFail=2)]
	public void MultiFail(){
 	QAssert.False(true); //AvailFail=1
	QAssert.True(false); //AvailFail=2
	QAssert.True(true);
	}
