    [Test]
    public void ProductDTO_ToModel_Mapping_IsValid()
    {
        //Arrange
        Mapper.CreateMap<productModel, ProductDTO>();
    
        //Act
    
        //Assert
        Mapper.AssertConfigurationIsValid();
    }
