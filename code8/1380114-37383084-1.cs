    SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database4.mdf;Integrated Security=True");
    try
    {
        String name = txtName.Text;
        String id = txtId.Text;
        String address = txtAdd.Text;
        String tel = txtTel.Text;
        String SqlQuery = "UPDATE [Table] SET name = @name, tel = @tel, [address] = @address where [id] = @id";
        SqlCommand cmnd = new SqlCommand(SqlQuery, con);
        cmnd.Parameters.AddWithValue("@id", id);
        cmnd.Parameters.AddWithValue("@name", name);
        cmnd.Parameters.AddWithValue("@tel", tel);
        cmnd.Parameters.AddWithValue("@address", address);
        con.Open();
        cmnd.ExecuteNonQuery();
        MessageBox.Show("Saved Successfully");
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error occured while saving" + ex);
    }
    finally
    {
        con.Close();
    }
