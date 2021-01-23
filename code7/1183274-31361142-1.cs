    private void button1_Click(object sender, EventArgs e)
    {
        if (!Directory.Exists("Test"))
        {
            DirectoryInfo dir = Directory.CreateDirectory("Test");
            dir.Attributes = FileAttributes.Directory | FileAttributes.Hidden;
        }
        // NO ELSE, the folder should remain hidden until you check the 
        // correctness of the password
        String password = "123";
        if ((textBox1.Text == password))
        {
            
            // This should be moved before opening the second form
            var dir = new DirectoryInfo("Test");
            // To remove the Hidden attribute Negate it and apply the bit AND 
            dir.Attributes = dir.Attributes & ~FileAttributes.Hidden;
            // Now you can hide the Unlock form, but please note
            // that a call to ShowDialog blocks the execution of
            // further code until you exit from the opened form
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
            // No code will be executed here until you close the f2 instance
            .....
        }
        else
            MessageBox.Show("Incorrect Password or Username", "Problem");
