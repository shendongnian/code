     using (var transactionScope = new System.Transactions.TransactionScope(TransactionScopeOption.Required, new TimeSpan(0, 10, 0)))
                {
                    try
                    {
                        ctx.BulkInsert(productsToSync, new BulkInsertOptions()
                        {
                            TimeOut = 10 * 60 * 1000
                        });
                        await ctx.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        SystemLogManager.AddDataSyncErrorLog(ex);
                    }
                    finally
                    {
                        transactionScope.Complete();
                    }
                }
