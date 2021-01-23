    try
    {
        using(SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\User\documents\visual studio 2012\Projects\WindowsFormsApplication1\WindowsFormsApplication1\Database4.mdf;Integrated Security=True"))
        {
            con.Open();
            using(SqlCommand cmnd = con.CreateCommand())
            {
                // Your update query must look like something like this
                cmnd.CommandText = @"UPDATE [Table] 
                                     SET   Name = @name, 
                                           Tel = @tel, 
                                           Address = @address 
                                     WHERE Id = @id"; 
                cmd.Parameters.Add(new SqlParameter("@id", txtId.Text));
                cmd.Parameters.Add(new SqlParameter("@name", txtName.Text));
                cmd.Parameters.Add(new SqlParameter("@tel", txtTel.Text));
                cmd.Parameters.Add(new SqlParameter("@address", txtAdd.Text));
                cmnd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully");
            }
        }
    }
    catch(Exception ex)
    {
        //Handle your exception here 
    }
