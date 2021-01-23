    private void CalculateResult()
    {
        try
        {
            double a = double.Parse(textBox1.Text);
            double b = double.Parse(textBox2.Text);
            double c = 0;//Set the result to 0 as a default.
            if (listBox1.SelectedItem == "%")
            {
                c = a / b * 100;
            }
            if (listBox1.SelectedItem == "rs")
            {
                c = a + b;
            }
            textBox3.Text = c.ToString();
        }
        catch(Exception err)
        {
            MessageBox.Show(err.Message);//Display error message if necessary.
        }
    }
