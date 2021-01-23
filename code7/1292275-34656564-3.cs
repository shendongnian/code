    private void ButtonEquals_Click(object sender, RoutedEventArgs e)
    {
        Calculator calculate = new Calculator();
        textBox.Text = calculate.Calculate(innerTextBox.Text);
        var item = new ListViewItem();
        item.Content = innerTextBox.Text + "=" + textBox.Text;
        item.Selected += HistoryItem_Selected //hooks the handler to the 'Selected' event
        history.Items.Add(item);
    
        innerTextBox.Clear();
    }
