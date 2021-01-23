    Label2.Visible = true;
    Label2.ForeColor = System.Drawing.Color.Red;
    int val;
    if (Int32.TryParse(TextBox6.Text, out val) && val < int.MaxValue) {
        using (SqlConnection scon = new SqlConnection(cs))
        {
            SqlCommand cmd = new SqlCommand("spDelete", scon);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", TextBox6.Text);
            scon.Open();
            int del = cmd.ExecuteNonQuery();
            if (del == 0)
            {
                Label2.Text = TextBox6.Text + " Record not found";
            }
            else
            {
                Label2.Text = TextBox6.Text + " Deleted Successfully";
                LoadGV();
            }
        }
    }
    else
    {
        Label2.Text = TextBox6.Text + " Enter a valid value";
    }
