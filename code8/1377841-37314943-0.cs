    protected void Button1_Click(object sender, EventArgs e)
    {
        con.Open();
        
        SqlDataReader reader;
        SqlCommand cmd = new SqlCommand("select stock from Inventory, con);
        cmd.CommandType = CommandType.Text;
        reader = cmd.ExecuteReader();
        // Data is accessible through the DataReader object here. You'll have to fill this part in
        cmd.ExecuteNonQuery();
        if (txtstockremove.Text <= currentStock)
        {
        SqlCommand cmd = new SqlCommand("update Inventory set stock= stock - '" + txtstockremove.Text + "' where model_number='" + txtmodelno.Text + "'", con);
        cmd.ExecuteNonQuery();
        }
        else
        {
            Label1.Visible = true;
            Label1.Text = "Stock Successfully Removed!";
        }
        con.Close();
        GridView1.DataBind();
        Label1.Visible = true;
        Label1.Text = "Stock Successfully Removed!";
    }
