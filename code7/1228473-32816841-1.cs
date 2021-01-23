    protected void RadListBox2_Inserted(object sender, RadListBoxEventArgs e)
    {
        for (int i = 0; i < e.Items.Count; i++)
        {
            lblInsertedList2.Text += e.Items[i].Text + ", " + "&nbsp;";
        } 
       
    }
