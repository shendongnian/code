        public static void InsertOnSubmitExplicitly<TEntity>(this Table<TEntity> table, TEntity obj)
            where TEntity : class
        {
            ChangeSet preSet = table.Context.GetChangeSet();
            if (preSet == null)
                throw new Exception("Unable to retrieve change set on data context before insert");
            table.InsertOnSubmit(obj);
            ChangeSet postSet = table.Context.GetChangeSet();
            if (postSet == null)
                throw new Exception("Unable to retrieve change set on data context after insert");
            var markAsDeleted = (from post in postSet.Inserts.Where(n => !ReferenceEquals(n, obj))
                                 join pre in preSet.Inserts on post equals pre into temp1
                                 from t1 in temp1.DefaultIfEmpty()
                                 where t1 == null
                                 select post);
            foreach (var entity in markAsDeleted)
                table.Context.GetTable(entity.GetType()).DeleteOnSubmit(entity);
        }
