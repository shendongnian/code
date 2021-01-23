            //selecting all the records of 2014
            IEnumerable<DataRow> dtrow = default(IEnumerable<DataRow>);
            dtrow = yourtable.AsEnumerable().Where(x => x.Field<Int64>("year") == Convert.ToInt64("2014"));
            if (dtrow.Count() > 0)
            {
                dataTbl = newrow.CopyToDataTable(); //dataTbl is the DataTable
            }
