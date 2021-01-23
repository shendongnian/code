    con = new SqlConnection("server=sameer-PC;database=Demo;Integrated Security=true;UID=admin;password=admin");
    //String query = "select * from user";
    con.Open();
    cmd = new SqlCommand("select * from [user]", con);
    Console.WriteLine("connection open{0}");
    SqlDataReader myReader = null;
    myReader = cmd.ExecuteReader();
    while (myReader.Read())
    {
         Console.Write((myReader["name"]));
    }
    con.Close();
}
