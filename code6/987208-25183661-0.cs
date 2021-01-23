                    SqlDataAdapter daAutoNum = new SqlDataAdapter();
                    using (ctx.Connection = DBUtil.GetSqlConnection(ctx.AppCode, this.DBName))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(BuildSelect(), ctx.Connection);
                        SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(adapter);
                        adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                        adapter.UpdateCommand = sqlBuilder.GetUpdateCommand();
                        adapter.InsertCommand = sqlBuilder.GetInsertCommand();
                        string scope_id = string.Format(" ; select {0} from {1} where {0} = SCOPE_IDENTITY();", PrimaryKeyName, MainTableName);
                        adapter.InsertCommand.CommandText += scope_id;
                        adapter.DeleteCommand = sqlBuilder.GetDeleteCommand();
                        SqlParameter identParam = new SqlParameter("@Identity", PrimaryKeyType, 0, PrimaryKeyName);
                        identParam.Direction = ParameterDirection.Output;
                        adapter.InsertCommand.Parameters.Add(identParam);
                        adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord;
                        daAutoNum.DeleteCommand = adapter.DeleteCommand;
                        daAutoNum.InsertCommand = adapter.InsertCommand;
                        daAutoNum.UpdateCommand = adapter.UpdateCommand;
                        daAutoNum.InsertCommand.Transaction = ctx.Transaction;
                        daAutoNum.DeleteCommand.Transaction = ctx.Transaction;
                        daAutoNum.UpdateCommand.Transaction = ctx.Transaction;
                      
                        daAutoNum.Update(ctx.Data, MainTableName);
                                  
                    }
