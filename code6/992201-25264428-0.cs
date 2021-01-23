    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var item = (ComboBoxItem)ComboBox.SelectedItem;
        if (item == null) 
            return;
        var content = (string) item.Content;
        if(content == "Something")
        {
            label1.Visible = true;
            label2.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }
    }
