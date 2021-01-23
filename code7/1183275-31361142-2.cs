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
            // A directory usually has the FileAttributes.Directory that has
            // a decimal value of 16 (10000 in binary). The Hidden attribute
            // has a decimal value of 2 (00010 in binary). So when you folder
            // is Hidden its decimal Attribute value is 18 (10010) 
            // Negating (~) the Hidden attribute you get 11101 binary 
            // that coupled to the curren value of Attribute gives 
            // 10010 & 11101 = 10000 or just FileAttributes.Directory
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
