    private void button1_Click(object sender, EventArgs e)
        {
            string s = label1.Text;
            string[] words = s.Split('x');
            Left_txtbox.Text = words[0].Trim();
            Right_Textbox.Text = words[1].Trim();
        }
