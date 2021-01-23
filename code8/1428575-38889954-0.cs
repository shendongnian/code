    public void AddDataInBatchGrid(object obj)
            {
                var data = new SearchItemsModel
                                {
                                    BatchNumber = msearchItems.BatchNumber,
                                    MFDDate = msearchItems.MFDDate,
                                    ExpiryDate = msearchItems.ExpiryDate,
                                    Quantity = msearchItems.Quantity,
                                };
                this.BatchItemsGrid.Add(data);           
            }
