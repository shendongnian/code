        private void btnDelete_Click(object sender, EventArgs e)//delete book
                {
                   Sqlconection cn = new Sqlconection("your connection string");
                    cn.Open();
                    SqlCommand com = new SqlCommand("DELETE FROM [tbl_Book] WHERE Book_ID='"+txtBookID.Text+"'",cn );
                  
                    com.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Book Deleted Successfully", "System", MessageBoxButtons.OK, MessageBoxIcon.Information);
        
                }
