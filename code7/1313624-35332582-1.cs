       private void btnDelete_Click(object sender, EventArgs e)
       {
             Sqlconection connection = new Sqlconection("Your Connection String Here");
             connection.Open();
             SqlCommand com = new SqlCommand("DELETE FROM [tbl_Book] WHERE Book_ID='"+txtBookID.Text+"'", connection);
             com.ExecuteNonQuery();
             connection.Close();
             MessageBox.Show("Book Deleted Successfully", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
       }
