    using (Context context = new Context())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                 ...yours code
                 context.SaveChanges();
                 dbContextTransaction.Commit();
                }
            }
