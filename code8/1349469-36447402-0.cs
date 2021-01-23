    static Random randNum = new Random((int)DateTime.Now.Ticks); 
    public static string CreateRandomPassword()  //If you are always going to want 8 characters then there is no need to pass a length argument
        {
            string _allowedChars = "1234567899999";
            
            char[] chars = new char[5];
            //again, no need to pass this a variable if you always want 8
        for (int i = 0; i < 5; i++)
        {
            chars[i] = _allowedChars[randNum.Next(_allowedChars.Length)];
        }
        return new string(chars);
    }
    protected void Button1_Click(object sender, EventArgs e)
        {
            int num; 
            if ( int.TryParse(ids.Text,out num))
            {
                for (int i = 1; i <= num; i++)
                {
                    var sand = CreateRandomPassword();
                    string strcon = ConfigurationManager.ConnectionStrings["slxserv"].ToString();
                    using (SqlConnection con = new SqlConnection(strcon))
    
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO passwords (password) VALUES (@password) "))
                    {
                        cmd.Connection = con;
                        cmd.Parameters.AddWithValue("@password",sand);
    
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
    }
