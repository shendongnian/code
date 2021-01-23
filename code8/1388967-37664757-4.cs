    private void listView1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == 13)
        {
            if(listView1.SelectedItems.Count > 0)
            {
                string studentID = listView1.SelectedItems[0].Text;
                DetailForm ti = new DetailForm(studentID);
                ti.Show();
                e.Handled = true;
            }
        }
    }
