    private void listView1_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Up)
        {
            if (listView1.Items[0].Selected)
            {
                this.ActiveControl = textBox1;
            }
        }
    }
