    using(TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required)){
				using(DbConnection dbConnection = SqlCeConnectionFactory.CreateConnection(DatabaseName)){
					dbConnection.Open();
					using(BillContext billContext = new BillContext(dbConnection, true)){
						billContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [Eras] ON");
						billContext.Eras.Add(new Era{Id = 87, Code = 87});
						billContext.SaveChanges();
						billContext.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT [Eras] OFF");
						transactionScope.Complete();
					}
					dbConnection.Close();
				}
			}
