                    if (DtWithTableName.Rows.Count > 0)
                    {
                    using (SqlBulkCopy s = new SqlBulkCopy(strConnection))
                    {
                    try
                    {
                        s.DestinationTableName = "HOMaterialReceiptDetails";
                        s.ColumnMappings.Add("MasterID", "MasterID");
                        s.ColumnMappings.Add("ItemID", "ItemID");
                        s.ColumnMappings.Add("SubCategoryID", "SubCategoryID");
                        s.ColumnMappings.Add("ExpiryDate", "ExpiryDate");
                        s.ColumnMappings.Add("BrandName", "BrandName");
                        s.ColumnMappings.Add("Qty", "Qty");
                        s.ColumnMappings.Add("FreeQty", "FreeQty");
                        s.ColumnMappings.Add("ReturnQty", "ReturnQty");
                        s.ColumnMappings.Add("ReplacementQty", "ReplacementQty");
                        s.WriteToServer(DtWithTableName);
                    }
                    catch (Exception)
                    {
                        IsInserted = false;
                    }
                }
            }
