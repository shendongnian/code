    private void DeleteExtraBtn_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\v11.0; AttachDbFilename=C:\Users\Donald\Documents\Visual Studio 2013\Projects\DesktopApplication\DesktopApplication\Student_CB.mdf ;Integrated Security=True");
        con.Open();
        try
        {
            //Delete selected extra row    
            SqlCommand sda = new SqlCommand("Delete From Extra Where Extra_ID = @ExtraID", con);
            sda.Parameters.AddWithValue("@ExtraID", extraGridView.CurrentRow.Cells[0].Value);
            sda.ExecuteNonQuery();
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    
    
        con.Close();
        loadExtraTable();
    }
