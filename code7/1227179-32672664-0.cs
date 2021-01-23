    string[] nameArray = new string[5];
	void CopyTextBoxesToArray()
	{
        nameArray[0] = textBoxName1.Text;
        nameArray[1] = textBoxName2.Text;
        nameArray[2] = textBoxName3.Text;
        nameArray[3] = textBoxName4.Text;
        nameArray[4] = textBoxName5.Text;
	}
    private void button9_Click(object sender, EventArgs e)
    {
		CopyTextBoxesToArray();
        Array.Sort(nameArray);
        foreach(string s in nameArray)
        {
            richTextBox1.Text += s + " ";
        }
    }
