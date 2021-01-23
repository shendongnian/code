    private void sum_Click(object sender, RoutedEventArgs e)
    {
        double n1;
        double n2;
        double n3;
        if (double.TryParse(num1.Text, out n1)
            && double.TryParse(num2.Text, out n2)
            && double.TryParse(num3.Text, out n3))
        {
            double sum = n1 * 4 + n2 * 5 + n3 * 5;
            sum1.Text = sum.ToString();
        }
        else
        {
            sum1.Text = "Unesi sve!";
        }
    }
