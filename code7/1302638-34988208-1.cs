     SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.Connection = con;
                comm.CommandText = "sptest" ;
                comm.Parameters.Add("@model", SqlDbType.NVarChar,20).Value = textBox1.Text; 
    ...
