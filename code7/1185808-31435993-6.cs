                foreach (string file in Directory.EnumerateFiles(Path1, "*.xml"))
                {
                    string newFile = path2 + @"\" + Path.GetFileName(file);
                    DataSet ds = new DataSet();
                    ds.ReadXml(file);
                    DataTable dt1 = ds.Tables["Order"];
                    DataTable dt2 = ds.Tables["Details"];
                    using (SqlBulkCopy bc = new SqlBulkCopy(con))
                    {
                        bc.ColumnMappings.Add("account", "account");
                        bc.ColumnMappings.Add("date", "date");
                        bc.ColumnMappings.Add("value", "value");
                        bc.DestinationTableName = "header";
                        bc.WriteToServer(dt1);
                    }
                    using (SqlBulkCopy bc = new SqlBulkCopy(con))
                    {
                        bc.ColumnMappings.Add("itemID", "itemID");
                        bc.ColumnMappings.Add("qty", "qty");
                        bc.ColumnMappings.Add("price", "price");
                        bc.DestinationTableName = "items";
                        bc.WriteToServer(dt2);
                    }
                    if (File.Exists(newFile)) // Did we find the file?
                    {
                        File.Delete(file); // Yep, so delete it.
                    }
                    File.Move(file, newFile); 
               }
