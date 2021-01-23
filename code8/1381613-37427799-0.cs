    SqlConnection dbconnect = new SqlConnection("server=localhost;database=***;username=root;password=***");
    SqlCommand cmd;
        try
        {
            cmd = new SqlCommand("INSERT INTO accounts(product, quantity) VALUES(@prod, @quan)", dbconnect);
            cmd.Parameters.AddWithValue("@prod", Your_Text_Box.Text);
            cmd.Parameters.AddWithValue("@quan", Your_Text_Box.Text);
            dbconnect.Open();
            int result = cmd.ExecuteNonQuery();
            Response.Write(result);
        }
        catch (SqlException ex)
        {
            Response.Write(ex.ToString());
        }
        finally
        {
            dbconnect.Close();
            Response.Redirect("_______.aspx");
        }
