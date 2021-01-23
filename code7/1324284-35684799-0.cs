     OleDbConnection oc= new OleDbConnection("[pass your connection string]");
     OleDbCommand ocom = new OleDbCommand();
       ocom.CommandText = "Abc"; // Abc is stored procedure  
       ocom.Connection  = oc;
       ocom.CommandType = CommandType.StoreProcedure;
       ocom.Parameters.AddWithValue("@tableName","PQR") // pass your table name
       ocom.Parameters.AddWithValue("@databaseName","IJK"); // pass your database name
     OleDbDataAdapter oda = new OleDbDataAdapter(ocom);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridViewAttendanceDatabase.DataSource = dt;
