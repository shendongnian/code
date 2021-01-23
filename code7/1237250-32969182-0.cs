    TextBox target;
    private void Form1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.A)
        {
            target = textBox1;
        }
        if (e.KeyCode == Keys.B)
        {
            target = textBox2;
        }
        if (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1)
        {
            if(target != null)
            {
                int vA = int.Parse(target.Text);
                vA += 5;
                target.Text = (String)vA.ToString();
            }
        }
    }
