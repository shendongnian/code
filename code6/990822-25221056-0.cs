    private void button1_Click(object sender, EventArgs e)
        {
            string newstring = textBox1.Text;
            for(int i = 0; i<=9; i++)
            {
                if(newstring.Contains(i.ToString()))
                {
                    int start = newstring.IndexOf(i.ToString());
                    newstring = newstring.Remove(start, 1);
                }
            }
            textBox1.Text = newstring.Remove(newstring.Length - 1);
        }
