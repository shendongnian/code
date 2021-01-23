    public List<DSM_DocPropIdentify> GetDocPropIdentify(string docPropIdentifyID, string action, out string errorNumber)
        {
            errorNumber = string.Empty;
            List<DSM_DocPropIdentify> docPropIdentifyList = new List<DSM_DocPropIdentify>();
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            SqlDatabase db = factory.CreateDefault() as SqlDatabase;
            using (DbCommand dbCommandWrapper = db.GetStoredProcCommand("GetDocPropIdentify"))
            {
                // Set parameters 
                db.AddInParameter(dbCommandWrapper, "@DocPropIdentifyID", SqlDbType.VarChar, docPropIdentifyID);
                db.AddOutParameter(dbCommandWrapper, spStatusParam, DbType.String, 10);
                // Execute SP.
                DataSet ds = db.ExecuteDataSet(dbCommandWrapper);
                if (!db.GetParameterValue(dbCommandWrapper, spStatusParam).IsNullOrZero())
                {
                    // Get the error number, if error occurred.
                    errorNumber = db.GetParameterValue(dbCommandWrapper, spStatusParam).PrefixErrorCode();
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        DataTable dt1 = ds.Tables[0];
                        docPropIdentifyList = dt1.AsEnumerable().Select(reader => new DSM_DocPropIdentify
                        {
                            DocPropIdentifyID = reader.GetString("DocPropIdentifyID"),
                            DocPropertyID = reader.GetString("DocPropertyID"),
                            DocCategoryID = reader.GetString("DocCategoryID"),
                            DocTypeID = reader.GetString("DocTypeID"),
                            OwnerID = reader.GetString("OwnerID"),
                            IdentificationCode = reader.GetString("IdentificationCode"),
                            IdentificationSL = reader.GetString("IdentificationSL"),
                            AttributeGroup = reader.GetString("AttributeGroup"),
                            IdentificationAttribute = reader.GetString("IdentificationAttribute"),
                            IsRequired = reader.GetInt16("IsRequired"),
                            IsAuto = reader.GetInt16("IsAuto"),
                            SetOn = reader.GetString("SetOn"),
                            SetBy = reader.GetString("SetBy"),
                            ModifiedOn = reader.GetString("ModifiedOn"),
                            ModifiedBy = reader.GetString("ModifiedBy"),
                            Status = reader.GetInt32("Status"),
                            Remarks = reader.GetString("Remarks")
                        }).ToList();
                    }
                }
            }
            return docPropIdentifyList;
        }
