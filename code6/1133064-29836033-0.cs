    //ADD SUBCATEGORY
    private void addsubcat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(combobox1.Text))
        {
            MessageBox.Show("You must select a category in which to add a subcategory.", "Invalid Operation: Data Missing", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        else
        {
            using (var sqlcmd = new SqlCommand("INSERT INTO subcategory_table (Category, Subcategory) VALUES(@category, @subcat);", sqlconnection))
            {
                sqlcmd.Parameters.AddWithValue("@category", this.comboxbox1.SelectedValue); // Added this line, and the corresponding parts in the INSERT statement above.
                sqlcmd.Parameters.AddWithValue("@subcat", this.subcat_txtbx.Text);
                sqlcmd.ExecuteNonQuery();
            }
        }
        this.DialogResult = DialogResult.OK;
        this.Close();
    }
