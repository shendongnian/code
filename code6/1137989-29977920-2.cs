    foreach (DataRowView dvrow in catcombobox.Items)
    {
        if (dvrow.ToString() == addcattxt.Text)
        {
            MessageBox.Show("This category already exists.", 
                            "Invalid Operation: Duplicate Data", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
            break;//<----- yeah jeff right no break here to
        }
        else
        {
            var query = "INSERT INTO category_table (Category) VALUES(@cat);";
            using (var sqlcmd = new SqlCommand(query, sqlconnection))
            {
                sqlcmd.Parameters.AddWithValue("@cat", this.addcattxt.Text);
                sqlcmd.ExecuteNonQuery();
            }
        }
    }
