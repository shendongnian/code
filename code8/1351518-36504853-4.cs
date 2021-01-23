    int i;
    private void timer1_Tick(object sender, EventArgs e)
    {            
        if (i > listBox1.Items.Count - 1)
        {
            i = 0;//Set this to repeat
            return;
        }
        textBox2.Text = listBox1.Items[i].ToString();
        i++;
    }
