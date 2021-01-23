    String input = InputTextBox.Text;
    int result = 0;
    if (int.TryParse(input, out result))
    {
        MyListBox.Items.Add(result);
    }
    else
    {
        var sum = this.MyListBox.Items.Cast<int>().Sum();
        MessageBox.Show(string.Format("Sum is: {0}", sum));
        sum.ToString();
    }
    InputTextBox.Text = String.Empty;
