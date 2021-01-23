        public DataTable SelectFromDB(String Sql)
        {
            
            var Class_Connection = new SQL_Connection();
            
            Class_Connection.cnn.Open();                
            var myDataAdaptor = new SqlDataAdapter(Sql, Class_Connection.cnn);
            var myDataTable = new DataTable();
            try
            {
                myDataAdaptor.SelectCommand.Connection = Class_Connection.cnn;
                myDataAdaptor.SelectCommand.CommandText = Sql;
                myDataAdaptor.SelectCommand.CommandType = CommandType.Text;
                myDataAdaptor.Fill(myDataTable);
                Class_Connection.cnn.Close(); 
                return myDataTable;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Class_Connection.cnn.Close();
                return null;
            }
        }
    var sql = new SQL_Statements();
    var stringSql = "select col1, col2, col3, col4 from table1 where col5=" + stringPO_NUM;
    var sql_ds = sql.SelectFromDB(stringSql);
    GV_POI.DataSource = sql_ds;
    GV_POI.DAtaBind();
    <asp:GridView ID="GV_POI" runat="server" AutoGenerateColumns="False">
        <EmptyDataTemplate>No records registered</EmptyDataTemplate>
    </asp:GridView>`
