    DataTable source = dataGridView1.DataSource as DataTable;
    var emptyrows = source.AsEnumerable()
    	                   .All(r=> r.ItemArray.All(x=> x == DBNull.Value));
    
    if(!emptyrows)
    {
       //export
    }
