    DataAccess access = new DataAccess();
    
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        access.IncomingValue += textBox1.Text;
    }
    
    private void button1_Click(object sender, EventArgs e)
    {
        MessageBox.Show(access.SaveToDatabase());
    }
