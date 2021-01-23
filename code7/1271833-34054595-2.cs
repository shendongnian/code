    private void CreateTable(String TableName, System.Data.SqlClient.SqlConnection conn)
    {
        StringBuilder sql = new StringBuilder(@"create table [");
        sql.Append(TableName);
        sql.AppendLine(@"] (");
        switch (TableName)
        {
            case "Vehicle":
                sql.AppendLine("[VIN] varchar(100),");
                sql.AppendLine("[Manufacturer] varchar(100),");
                sql.AppendLine("[Model] varchar(100),");
                sql.AppendLine("[Year] integer");
                break;
            case "Repair":
                sql.AppendLine("[VIN] varchar(100),");
                sql.AppendLine("[Correction] varchar(100),");
                sql.AppendLine("[Price] decimal");
                break;
        }
        sql.Append(")");
        System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(
            sql.ToString, conn);
        try
        {
            cmd.ExecuteNonQuery();
            MessageBox.Show("Created Table " + TableName);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Oops, I did it again");
        }
    }
