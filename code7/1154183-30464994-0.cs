    private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
    {
        //some other code
    }
    private void Form_Load(object sender, EventArgs e)
    {
        int days = 31;
        for (int i = 1; i <= days; i++)
        {
            this.dayComboBox.Items.Add(i);
        }
    }
