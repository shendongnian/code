		Configure.DataBaseIntegration(db =>
		                              {
		                              	db.Dialect<MsSql2008Dialect>();
		                              	db.Driver<SqlClientDriver>();
		                              	db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
		                              	db.IsolationLevel = IsolationLevel.ReadCommitted;
		                              	db.ConnectionStringName = System.Environment.MachineName;
		                              	db.BatchSize = 20;
		                              	db.Timeout = 10;
		                              	db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
		                              });
