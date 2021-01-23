    foreach (DataGridViewRow Myrow in dgMember_Grade.Rows)
    {
    	if (Myrow.Cells[26].Value == null) {
    		continue;
    	}
    	
    	DateTime expiredate = DateTime.Parse(Myrow.Cells[26].Value.ToString());
    	if (expiredate < DateTime.Now) 
    	{
    		Myrow.DefaultCellStyle.BackColor = Color.Red;
    	}
    	else
    	{
    		Myrow.DefaultCellStyle.BackColor = Color.Green;
    	}
    }
