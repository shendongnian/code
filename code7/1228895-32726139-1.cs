    public static int UpdateUserTitles(UserTitle userTitle)
        {
            using (ITransaction transaction = Context.BeginTransaction())
            {
                Context.Save(userTitle);
                transaction.Commit();
            }
            return 0;
        }
