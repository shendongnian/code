    bool CheckLoginDetails(string username, string password){
    DataTable dt = new DataTable ();
    MySqlCommand command = new MySqlCommand ("select * from accounts where username = @username;", SL.Database.connection);
    command.Parameters.AddWithValue ("@username", username);
    dt.Load (command.ExecuteReader());
}
