    public void TestVerifyGetAddressIsCalled(){ 
        //Arrange
        var genAddress = new Mock<IGenerateAddress>();
        
        var objSaveAddress = new SaveAddress(genAddress.Object);
        
        var name = "dddd";
        //Act
        objSaveAddress.Save(name);
    
        //Assert
        //Verify if IGenerateAddress 'GenerateAddress' is called    
        genAddress.Verify(a=>a.GenerateAddress(name),Times.Once);
    }
