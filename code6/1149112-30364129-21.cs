	private void button1_Click(object sender, EventArgs e)
	{
		// Call ActiveX
		//myObject.SayHello("C# Button");
		this.webBrowser1.Document.InvokeScript("eval",
			new[] { "MyObject.SayHello('C# Button')" });
	}
