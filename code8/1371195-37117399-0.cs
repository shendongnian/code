      [Test()]
            public void GetEmailTemplateFiltersTest()
            {
                using (ShimsContext.Create())
                {
                    #region ARRANGE
                    var rowCounter = 0;
    
                    ShimSqlConnection.AllInstances.Open = (sender) => { };
                    ShimSqlConnection.AllInstances.StateGet = (sender) => ConnectionState.Open;
                    ShimSqlCommand.AllInstances.ExecuteReader = (sender) => new ShimSqlDataReader();
                    ShimDbDataReader.AllInstances.Dispose = (sender) => { };
                    ShimDbDataReader.AllInstances.DisposeBoolean = (sender, p1) => { };
    
                    ShimSqlDataReader.AllInstances.Read = (sender) =>
                    {
                        rowCounter++;
                        return rowCounter <= 2;
                    };
    
                    ShimSqlDataReader.AllInstances.ItemGetString = (sender, coloumnName) =>
                    {
                        if (rowCounter == 1)
                        {
                            switch (coloumnName)
                            {
                                case "InvoiceEmailMapParmId":
                                    return 1;
                                case "ParmName":
                                    return "Param1";
                                default:
                                    return "SomeStrigValue";
                            }
                        }
                        else if (rowCounter == 2)
                        {
                            switch (coloumnName)
                            {
                                case "InvoiceEmailMapParmId":
                                    return 1;
                                case "ParmName":
                                    return "Param1";
                                default:
                                    return "SomeStrigValue";
                            }
                        }
                        else
                        {
                            return string.Empty;
                        }
                    }; 
                    #endregion
    
                    //ACT
                    var filterList = _sut.GetEmailTemplateFilters();
    
                    //ASSERT
                    Assert.That(filterList.Length, Is.EqualTo(2));
    
                }
            }
