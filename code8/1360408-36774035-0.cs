    public void TestVerifyGetAddressIsCalled(){ 
        var genAddress = new Mock<IGenerateAddress>();
        
        var objSaveAddress = new SaveAddress(genAddress .Object);
        
        var args = "dddd";
        objSaveAddress.Save(args);
    
        //Verify if IGenerateAddress 'GenerateAddress' is called
    
        genAddress.Verify(a=>a.GenerateAddress(args),Times.Once);
    }
