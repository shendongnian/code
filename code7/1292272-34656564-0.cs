    private void ButtonEquals_Click(object sender, RoutedEventArgs e)
    {
        Calculator calculate = new Calculator();
        textBox.Text = calculate.Calculate(innerTextBox.Text);
        var item = new ListViewItem();
        item.Content = innerTextBox.Text + "=" + textBox.Text;
        item.Selected += HistoryItem_Selected
        history.Items.Add(item);
    
        innerTextBox.Clear();
    }
