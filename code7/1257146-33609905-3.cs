    public void button1_Click(object sender, EventArgs e)
    {
        MyClass c = new MyClass();
        try
        {
            MyClass.WriteToFile(textBox1.Text))
            MessageBox.Show("success, managed to write to the file");
        }
        catch(Exception e)
        {
            MessageBox.Show("Error, Could not write to file. " + e.Message);
        }
    }
