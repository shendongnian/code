    private void button1_Click(object sender, EventArgs e)
    {
        string no1 = label1.Text;
        string no2 = label2.Text;
        if (!IsValidNumber(no1))
        {
            MessageBox.Show(String.Format("The text {0} is not a valid number", no1));
            return;
        }
        if (!IsValidNumber(no2))
        {
            MessageBox.Show(String.Format("The text {0} is not a valid number", no2));
            return;
        }
        double result = Convert.ToDouble(no1) + Convert.ToDouble(no2);
        label3.Text = result.ToString();
    }
    bool IsValidNumber(string textValue)
    {
        try
        {
            Convert.ToDouble(textValue);
        }
        catch
        {
            return false;
        }
        return true;
    }
