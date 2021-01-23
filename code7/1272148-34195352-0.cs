    public static Supplier_Claim_Upload_Result ExcludeFailedValidationRecords()
        {
            IList<CRMSupplierClaimsData> claimsData = GetClaimsUpdateRecordsFromStaging();
            Supplier_Claim_Upload_Result supplierClaimUplaod = new Supplier_Claim_Upload_Result();
            //Supplier_Claim_Uplaod_Result_Error supplierClaimUploadError = new Supplier_Claim_Uplaod_Result_Error();
            var sqlConnection = "data source=WMVSQL02;initial catalog=Embrace;integrated security=True;";
            using (SqlConnection conn = new SqlConnection(sqlConnection))
            {
                try
                {
                    foreach (var claim in claimsData)
                    {
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandTimeout = 60;
                        SqlDataReader reader;
                        cmd.CommandText = "CRM.Supplier_Claim_Upload";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Invoice", SqlDbType.NVarChar).Value = claim.LineNunber;
                        cmd.Parameters.Add("@Amount", SqlDbType.Decimal).Value = claim.TotalClaim;
                        cmd.Connection = conn;
                        conn.Open();
                        reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            supplierClaimUplaod.ST_Key = reader["ST_Key"].ToString();
                            if (supplierClaimUplaod.SupplierClaim != null)
                            {
                                supplierClaimUplaod.SupplierClaim = reader["Supplier_Claim"].ToString();
                            }
                            else if (supplierClaimUplaod.SupplierClaim == null)
                            {
                                if (supplierClaimUplaod.Error != null)
                                {
                                    supplierClaimUplaod.Error = reader["Error"].ToString();
                                }
                                else if (supplierClaimUplaod.Error == null)
                                {
                                    supplierClaimUplaod.SupplierClaim = "No value";
                                }
                            }
                            if (supplierClaimUplaod.OrigInv != null)
                            {
                                supplierClaimUplaod.OrigInv = reader["Orig_Inv"].ToString();
                            }
                            else if (supplierClaimUplaod.OrigInv == null)
                            {
                                if (supplierClaimUplaod.Error != null)
                                {
                                    supplierClaimUplaod.Error = reader["Error"].ToString();
                                }
                                else if (supplierClaimUplaod.Error == null)
                                {
                                    supplierClaimUplaod.OrigInv = reader["Orig_Inv"].ToString();
                                }
                            }
                            if (supplierClaimUplaod.SystemCost != null)
                            {
                                supplierClaimUplaod.SystemCost = reader["System_Cost"].ToString();
                            }
                            else if (supplierClaimUplaod.SystemCost == null)
                            {
                                if (supplierClaimUplaod.Error != null)
                                {
                                    supplierClaimUplaod.Error = reader["Error"].ToString();
                                }
                                else if (supplierClaimUplaod.Error == null)
                                {
                                    supplierClaimUplaod.SystemCost = reader["System_Cost"].ToString();
                                }
                            }
                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.InnerException);
                }
                return supplierClaimUplaod;
            }
        }
