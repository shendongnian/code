    public static void processOrder(int employeeId, int tableId, DateTime orderDate, DateTime orderBegin, bool orderStatus)
    {
        try
        {
            if (KaiConnection.State == ConnectionState.Closed)
                KaiConnection.Open();
            OleDbCommand cmd = new OleDbCommand("INSERT INTO [Order] (EmployeeID, [TableID], OrderDate, OrderBegin, OrderStatus)" +
                             " VALUES (@EmployeeID, @TableID, @OrderDate, @OrderBegin, @OrderStatus)", KaiConnection);
            
            OleDbParameter[] parameters = new OleDbParameter[5];
            parameters[0] = new OleDbParameter("@EmployeeID", OleDbType.Integer);
            parameters[1] = new OleDbParameter("@TableID", OleDbType.Integer);
            parameters[2] = new OleDbParameter("@OrderDate", OleDbType.Date);
            parameters[3] = new OleDbParameter("@OrderBegin", OleDbType.Date);
            parameters[4] = new OleDbParameter("@OrderStatus", OleDbType.Boolean);
            
            parameters[0].Value = employeeId;
            parameters[1].Value = tableId;
            parameters[2].Value = orderDate;
            parameters[3].Value = orderBegin;
            parameters[4].Value = orderStatus;
            
            for (int i = 0; i < 5; i++)
            {
                cmd.Parameters.Add(parameters[i]);
            }
            cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            KaiConnection.Close();
        }
        catch (Exception ex)
        {
            MessageBox.Show((ex.ToString()));
        }
    }
    
