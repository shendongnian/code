    foreach (DataGridViewRow Myrow in dgMember_Grade.Rows)
    {
        var cellValue = Myrow.Cells[26].Value;
        if (cellValue == null || cellValue == DBNull.Value)
            continue;
        DateTime expiredate = Convert.ToDateTime(cellValue);
        if (expiredate < DateTime.Now)
        {
            Myrow.DefaultCellStyle.BackColor = Color.Red;
        }
        else
        {
            Myrow.DefaultCellStyle.BackColor = Color.Green;
        }
    }
