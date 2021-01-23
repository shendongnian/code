    label1.Text=textBox1.Text;
    string providerName = "System.Data.EntityClient";
    string connection = "datasource=students.mssql.somee.com;port=4096;username=mhs_SQLLogin_1;password=gtwhp7td39";
    try{
    SqlConnection Conn=new SqlConnection(connection);
    SqlDataAdapter DataAdapter=new SqlDataAdapter();
    SqlCommandBuilder cb=new SqlCommandBuilder(DataAdapter);
    Conn.Open();
    MessageBox.Show("Connected!");
    Conn.Close();
    }catch(Exception ex){
    }
