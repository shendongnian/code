    string con = "SERVER=localhost; user id=root; password=; database=dbname";
    private void getMaxID()
    {
    MySqlConnection connect = new MySqlConnection(con);
    MySqlCommand cmd = new MySqlCommand("SELECT MAX(ID) as 'aydi' FROM data1");
    cmd.CommandType = CommandType.Text;
    cmd.Connection = connect;
    connect.Open();
    MySqlDataReader dr;
    try
    }
    dr = cmd.ExecuteReader();
    while(dr.Read())
    {
    txtID.Text = dr.GetString("aydi");
    }
    dr.Close();
    {
    catch(Exception ex)
    {
    MessageBox.Show(ex.Message);
    }
    finally
    {
    if(connect.State == ConnectionState.Open)
    {
    connect.Close();
    }
    }
    }
