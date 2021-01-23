    private void button1_Click(object sender, EventArgs e)
        {
            string s = label1.Text;
            Left_txtbox.Text = s.Split('x')[0].Trim();
            Right_Textbox.Text = s.Split('x')[1].Trim();
        }
    
