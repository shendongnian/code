                var objCtx = ((IObjectContextAdapter)ctx).ObjectContext;
                using (SqlCommand cmd = ctx.Database.Connection.CreateCommand() as SqlCommand)
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "<your proc here>";
                    var param = cmd.CreateParameter();
                    param.ParameterName = "@param1";
                    param.Value = someValue;
                    cmd.Parameters.Add(param);
                    await cmd.Connection.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        var results = objCtx.Translate<type1Here>(reader).ToList();
                        reader.NextResult();
                        var results2 = objCtx.Translate<type2Here>(reader).ToList();
                        reader.NextResult();
                        var results3 = objCtx.Translate<type3Here>(reader).ToList();
                        reader.NextResult();
                    }
                }
