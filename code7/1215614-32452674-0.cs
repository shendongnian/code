        using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required)) {
            using (var conn = new SqlConnection("your connection string")) {
                using (var db = new YourContext(conn, false)) {
                     db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ErrorCode ON");
                     foreach (ErrorCode ec in errorCodesStep3.errorcodesUsers) {
                          errorCode.ID = ec.ID;
                          errorCode.ParentID = ec.ParentID;
                          errorCode.ErrorDescription = ec.ErrorDescription;
                          db.ErrorCode.Add(errorCode);                            
                     }
                     db.SaveChanges();
                     db.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.ErrorCode OFF");
                     scope.Complete();
                }
            }
        }
