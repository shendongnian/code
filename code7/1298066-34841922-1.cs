    private float? try_get_input()
    {
        try
        {
            return float.Parse(textBox1.Text);
        }
        catch
        {
            return null;
        }
    }
    
    private void button1_Click(object sender, EventArgs e)
    { 
        textBox2.Clear();
        float? v = try_get_input();
        if (v != null)
        {
            textBox2.AppendText(Math.Sin(v.Value).ToString());
        }
        else
        {
            textBox2.AppendText("Invalid Input");
        }
    }
