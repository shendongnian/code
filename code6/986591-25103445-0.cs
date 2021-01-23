    private void TextChanged_EH(object sender, EventArgs ea)
    {
            // If the number of lines in the RichTextBox decreases, I could rewrite the lines in the TextBox
        if (this._rtb.Lines.Count() != rows)
        {
            //MessageBox.Show(this._rtb.Lines.Count().ToString());
            rows = this._rtb.Lines.Count();
            if (this._rtb.Lines.Count() > 1)// This is trash
            {
                this.textBox1.Text = "";//Clearing the TextBox
                //Redrawing the numbers that represent the number of lines.
                for (int i = 1; i <= rows; i++)
                {
                    this.textBox1.Text += i.ToString();
                    this.textBox1.Text += System.Environment.NewLine;
                }
            }
        }
    }
