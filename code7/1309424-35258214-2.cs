    [Test]
    public void ResovleDataReader_RowCount()
    {
        var dataReader = CreateDateReader();
        var view = ResolveDataReader(dataReader.Object);
        Assert.AreEqual(2, view.Count);
    }
    
    [Test]
    public void ResolveDataReader_NamesColumn1()
    {
        var dataReader = CreateDataReader();
        var view = ResolveDataReader(dataReader.Object);
        Assert.AreEqual(Column1, view.Table.Columns[0].ColumnName);
    }
    
    [Test]
    public void ResolveDataReader_PopulatesColumn1()
    {
        var dataReader = CreateDataReader();
        var view = ResolveDataReader(dataReader.Object);
        Assert.AreEqual(ExpectedValue1, view.Table.Rows[0][0]);
    }
    // Etc..
