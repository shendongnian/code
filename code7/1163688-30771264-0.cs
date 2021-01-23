            private void DGTest_gridBind()
        {
            DataTable table = new DataTable();
            table.Columns.Add("FName", typeof(string));
            table.Columns.Add("LName", typeof(string));
            table.Columns.Add("FullName", typeof(string), "FName + ' ' + LName");
            table.Rows.Add("Jack", "Miller");
            table.Rows.Add("Sam", "Tucker");
            DGTest.DataSource = table;
}
