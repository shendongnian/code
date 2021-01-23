    string collect = "";
    private void listBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        collect += e.KeyChar.ToString();
        if ((int)e.KeyChar == 13)
        {
            listBox1.Items.Add(collect);
            collect = "";
        }
    }
