    private List<string> ValidateB(byte[] fileByteArray)
    {
        List<string> errors = new List<string>();
        MemoryStream ms = new MemoryStream(fileByteArray);
        ms.Position = 0;
        ms.Seek(0, SeekOrigin.Begin);
        using (var parser = new TextFieldParser(ms))
        {
    	    // Processing...
    	}
    	
    }
