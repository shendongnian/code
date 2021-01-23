            Configure.DataBaseIntegration(db =>
                                          {
                                              db.Dialect<MsSql2008Dialect>();
                                              db.Driver<SqlClientDriver>();
                                              db.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                                              db.IsolationLevel = IsolationLevel.ReadCommitted;
                                              db.ConnectionString = _connectionString;
                                              db.BatchSize = 20;
                                              db.Timeout = 10;
                                              db.HqlToSqlSubstitutions = "true 1, false 0, yes 'Y', no 'N'";
                                          });
