    private void Button_Click(object sender, RoutedEventArgs e)
    {
        string sConn = @"Data Source=WOLFSQLDEV3;Initial Catalog=Ben;
                         User ID=tester1;Password=david;";
        using(SqlConnection sc = new SqlConnection(sConn))
        {
            sc.Open();
            string sql = "SELECT * FROM WolfAcademyForm WHERE [Forename]= @Forename";
            SqlCommand com = new SqlCommand(sql, sc);       
            com.Parameters.AddWithValue("@Forename", txtSearch.Text);
       
            using(SqlDataAdapter adapter = new SqlDataAdapter(com))
            {
               DataTable dt = new DataTable();
               adapter.Fill(dt);
               grdSearch.ItemsSource = dt.DefaultView;              
            }
        }
    }
