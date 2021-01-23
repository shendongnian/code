    private const string FilePath = @"C:\testfile.txt";
    private void buttonTxt_Click(object sender, EventArgs e)
    {
        if (radioReadMode.Checked) // check which radio button is selected
        {   // read mode
            string[] Test = File.ReadAllLines(FilePath);
            for (int i = 0; i < testfile.Length; i++)
                TextBox.Text += testfile[i];
        }
        else
        {   // write mode
            File.WriteAllText(FilePath, TextBox.Text);
        }
    }
