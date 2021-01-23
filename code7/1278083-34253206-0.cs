    private void button1_Click(object sender, EventArgs e)
    {
        int x = Convert.ToInt32(textBox1.Text);
        listBox1.Items.Clear();
        listBox1.Items.Add("1".ToString());
        double numerator = 1, Fact = 1, firstNum = 1, result=0;
        for (int i = 1; i <= 20; i++)
        {
            Fact = 1;		// Reinitialising every time for new denomerator.
            numerator = Math.Pow(x, i);		// This is how power is calculated.
            for (int j = 1; j<=i; j++)		// One more inner loop is needed for Factorial.
                Fact = Fact * j;
            result = numerator / Fact;
            firstNum = firstNum + (Math.Pow(-1, i) * result);	// This is the main logic for alternate plus minus.
            listBox1.Items.Add(firstNum.ToString());
        }
	}
