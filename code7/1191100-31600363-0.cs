    for(int i = 1; i <= 20; i++) {
    	TextBox t = (TextBox)GridView1.Rows[rowIndex].Cells[i-1].FindControl(String.Format("TextBox{0}", i));
    	SqlParameter p = new SqlParameter(String.Format("@ITEM{0}", i), SqlDbType.Int);
    	p.Value = t.Text;
    	tCommand.Parameters.Add(p1);
    }
