    [Test]
    [TestCase("30 12 30 10 06 08 2B 06 01 05 05 07 09 04 31 04 13 02 55 53")]
    public void ReadCitizenship(string example)
    {
    	// translates hex to byte[]
    	var encoded = Helpers.GetExampleBytes(example);
    
    	// initialize reader
    	var reader = Helpers.ReaderFromData(encoded);
    
    	// parse ASN.1 object to the end and read value as byte[]
    	var subjDirAttributes = reader.ReadToEnd(true);
    
    	// NO Checking for null has been done
    	//                                  sequence      sequence      set           printable string
    	var citizenship = subjDirAttributes.ChildNodes[0].ChildNodes[0].ChildNodes[1].ChildNodes[0];
    
    	var value = citizenship.ReadContentAsPrintableString();
    	Assert.IsTrue(value == "US");
    }
