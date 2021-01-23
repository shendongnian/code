    private void searchByID_Click(object sender, EventArgs e)
    {
        try
        {
            int id = int.Parse(textBox1.Text);
            DataRow[] foundList = ds.Tables["Emp"].Select("Id = " + id);
            if(foundList.Length > 0)
            {
                textBox2.Text = foundList[0].Field<string>("name");
                textBox3.Text = foundList[0].Field<string>("address");
                textBox4.Text = foundList[0].Field<int>("age").ToString();
                textBox5.Text = foundList[0].Field<int>("salary").ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
