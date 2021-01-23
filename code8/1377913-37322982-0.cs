        using (var table = new DataTable ())
        {
            table.Columns.Add("cs", typeof(string));
            foreach (var item in ITEMS)
                table.Rows.Add(item.CD.ToString());
            var param1 = new SqlParameter("@x", SqlDbType.NVarChar)
            {
                Value = myValue
            };
            var param2 = new SqlParameter("@c", SqlDbType.Structured)
            {
                Value = table
            };
            ((IObjectContextAdapter)this).ObjectContext.ExecuteStoreQuery<TestTbl_Result>(
                "select * from [TestTbl](@x, @c)", param1, param2);
        }
