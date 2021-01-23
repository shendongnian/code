    WhereCondition whereCondition = new WhereCondition();
                whereCondition.ColumName = "Id";
                whereCondition.Cond = Condetion.Equal;
                whereCondition.Value = id.ToString();
                Expression<Func<T, bool>> whereEx = GetWhereFunc(new List<WhereCondition>(){whereCondition}, GetType());
                return (from c in RDaynamicContext.GetTable(tbl)
                        select c).Where(whereEx).FirstOrDefault();
