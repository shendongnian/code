    // define query WITH PARAMETERS! Don't concatenate together your SQL - never EVER !
    string insertQry = "INSERT INTO [dbo].[KlienciIndywidualni] (TextCol1, TextCol2, TextCol3, TextCol4, TextCol5) " + 
                       "VALUES (@TextValue1, @TextValue2, @TextValue3, @TextValue4, @TextValue5);";
                       
    // create connection and command object                   
    using (SqlConnection conn = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\Mariusz\Desktop\SerwisKomputerowyDB\SerwisKomputerowyDB\SerwisKomputerowyDB\Database1.mdf; Integrated Security = True"))
    using (SqlCommand cmd = new SqlCommand(insertQry, conn))
    {
        // set up parameters and define values
        cmd.Parameters.Add("@TextValue1", SqlDbType.VarChar, 50).Value = textBox1.Text;
        cmd.Parameters.Add("@TextValue2", SqlDbType.VarChar, 50).Value = textBox2.Text;
        cmd.Parameters.Add("@TextValue3", SqlDbType.VarChar, 50).Value = textBox3.Text;
        cmd.Parameters.Add("@TextValue4", SqlDbType.VarChar, 50).Value = textBox4.Text;
        cmd.Parameters.Add("@TextValue5", SqlDbType.VarChar, 50).Value = textBox5.Text;
        // open connection, execute INSERT command, close connection  
        conn.Open();
        cmd.ExecuteNonQuery();
        conn.Close();
    }
}    
