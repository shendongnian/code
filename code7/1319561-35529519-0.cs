    <pre> <code> private DataTable getDataGridID()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
        //    dt.Rows.Add(dgTeamDashboard.Columns("ID");
            foreach (DataGridViewRow row in dgTeamDashboard.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Update"].Value) == true)
                dt.Rows.Add(row.Cells["ID"].Value);
            }
            return dt;
        }</code>
