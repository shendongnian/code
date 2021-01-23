    public void LoadAttendance()
        {
            con.Open();
            cmd = new OleDbCommand("Select * from AttendanceDatabase WHERE EmpName = @EmpName and Date between @d1 and @d2", con);
            cmd.Parameters.AddWithValue("@EmpName", txtEmpName.Text);
            cmd.Parameters.AddWithValue("@d1", dtDate1.Value.Date);
            cmd.Parameters.AddWithValue("@d2", dtDate2.Value.Date);
            DataAdapter = new OleDbDataAdapter(cmd);
            DataTable = new DataTable();
            DataAdapter.Fill(DataTable);
            dgvAttendance.DataSource = DataTable;
            con.Close();
        }
