            DataTable dtDestination = new DataTable();
            DataTable dtSource = new DataTable();
            dtSource.Columns.Add("Str1");
            dtSource.Columns.Add("Str2");
            dtDestination.Columns.Add("Str0");
            dtDestination.Columns.Add("Str1");
            dtDestination.Columns.Add("Str2");
            dtSource.Rows.Add("Foo", "Bar");
            dtSource.Rows.Add("Bob", "Smith");
            foreach (DataRow drSrc in dtSource.Rows)
            {
                DataRow drNew = dtDestination.NewRow();
                var array = new object[drSrc.ItemArray.Length];
                array[0] = "My";
                Array.Copy(drSrc.ItemArray, 0, array, 1, drSrc.ItemArray.Length);
                drNew.ItemArray = array;
                dtDestination.Rows.Add(drNew);
            }
