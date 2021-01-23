    private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionStart = richTextBox1.Text.Length; //Set the current caret position at the end
            richTextBox1.ScrollToCaret(); //Now scroll it automatically
        }
	private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) 
            {
                txtFileName.Text = openFileDialog1.FileName;
            }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            var result = File.ReadAllLines(@txtFileName.Text).Select(s => s.Contains(txt_search.Text));
		this.richTextBox1.AppendText(result.ToString()); //---> Appends the Text to the Rich Text Box, you may want to change the variable result(i hope its not a collection)
        }
