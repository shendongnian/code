    using System.Text.RegularExpressions;
    private void button1_Click(object sender, EventArgs e)
    {
        MatchCollection values = Regex.Matches(textBox1.Text, "[0-9]+");
        MatchCollection operations = Regex.Matches(textBox1.Text, @"[\/\*\+-]");
        if (values.Count == operations.Count + 1)
        {
            int total = int.Parse(values[0].Value);
            if (operations.Count > 0)
            {
                for (int index = 1; index < values.Count; index++)
                {
                    int value = int.Parse(values[index].Value);
                    switch (operations[index - 1].Value)
                    {
                        case "+":
                            total += value;
                            break;
                        case "-":
                            total -= value;
                            break;
                        case "/":
                            total /= value;
                            break;
                        case "*":
                            total *= value;
                            break;
                    }
                }
            }
            MessageBox.Show(total.ToString());
        }
    }
