	SqlParameter par_ItemCount = new SqlParameter("@itemcount", SqlDbType.Int);
	par_ItemCount.Value = int.Parse(item.SubItems[0].Text);
	cm.Parameters.Add(par_ItemCount);
	
	SqlParameter par_ItemCode = new SqlParameter("@itemcode", SqlDbType.Int);
	par_ItemCode.Value = int.Parse(item.Text);
	cm.Parameters.Add(par_ItemCode);
		
