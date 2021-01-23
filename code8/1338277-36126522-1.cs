    private void Savebtn_Click(object sender, EventArgs e)
    {
        int A, B, C;
        A = int.Parse(textBox1.Text);
        B = int.Parse(textBox2.Text);
        C = int.Parse(textBox3.Text);
        var calc = new MwCalculator();
        textBox4.Text = calc.MWCompute(A,B,C).ToString();
    }
