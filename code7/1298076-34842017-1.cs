    private bool try_get_input(out float val)
    {
        val = 0;
        try
        {
            val = float.Parse(textBox1.Text);
            return true;
        }
        catch
        {
            textBox2.Clear();
            textBox2.AppendText("Invalid Input");
        }
        return false;
    }
    private void button1_Click(object sender, EventArgs e)
    { 
        textBox2.Clear();
        float v = 0;
        if (try_get_input(out v))
        {
            textBox2.AppendText((Math.Sin(v)).ToString());
        }
    }
