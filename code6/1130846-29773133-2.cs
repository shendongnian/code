    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        panel1.Controls.Clear();
        UserControl control = (listBox1.SelectedItem as ListItem).Value;
        if(control != null)
        {
            panel1.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
    }
