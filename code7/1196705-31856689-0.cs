    private static DataTable SplitDataTableModule(DataTable d1)
        {
            DataTable dataTable1;
            dataTable1 = d1.Copy();
            dataTable1.Columns.RemoveAt(0); // remove student_no
            dataTable1.Columns.RemoveAt(1); // remove student surname
            dataTable1.Columns.RemoveAt(2); // remove student firstname
            dataTable1.Columns.RemoveAt(5); // remove staff_no
            dataTable1.Columns.RemoveAt(6); // remove staff surname
            dataTable1.Columns.RemoveAt(7); // remove staff firstname
            return d1;
        }
