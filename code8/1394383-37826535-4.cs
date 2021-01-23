    private void btnSendToFile_Click(object sender, EventArgs e)
    {
        string strName = txtName.Text;
        string strAge = txtAge.Text;
        string strTitles = ("Name \t\t Age");
        string strCombined = strTitles + "\n" + (strName + "\t\t" + strAge);
        MessageBox.Show("The Name and Age of the Person Entered Will be Written to a File");
        File.AppendAllText(saveFileDialog1.FileName, strCombined);
        MessageBox.Show("The Details Have Been Written to File" + saveFileDialog1.FileName);
    }
