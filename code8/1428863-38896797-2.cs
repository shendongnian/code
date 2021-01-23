    private void btn1_Click(object sender, EventArgs e)
    {
        Form2 f2= new Form2();
        if(f2.ShowDialog() == DialogResult.OK) //check the result
        {
            comboBox1.Items.Add(f2.Value);//Add the new item
        }
    }
