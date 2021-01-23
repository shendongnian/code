    private const string Column1 = "First";
    private const string Column2 = "Second";
    private const string ExpectedValue1 = "Value1";
    private const string ExpectedValue2 = "Value1";
    
    private static Mock<IDataReader> CreateDataReader()
    {
        var dataReader = new Mock<IDataReader>();
    
        dataReader.Setup(m => m.FieldCount).Returns(2);
        dataReader.Setup(m => m.GetName(0)).Returns(Column1);
        dataReader.Setup(m => m.GetName(1)).Returns(Column2);
    
        dataReader.Setup(m => m.GetFieldType(0)).Returns(typeof(string));
        dataReader.Setup(m => m.GetFieldType(1)).Returns(typeof(string));
    
        dataReader.Setup(m => m.GetOrdinal("First")).Returns(0);
        dataReader.Setup(m => m.GetValue(0)).Returns(ExpectedValue1);
        dataReader.Setup(m => m.GetValue(1)).Returns(ExpectedValue2);
    
        dataReader.SetupSequence(m => m.Read())
            .Returns(true)
            .Returns(true)
            .Returns(false);
        return dataReader;
    }
