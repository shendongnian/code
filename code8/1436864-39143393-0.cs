    private void yourTextBox_TextChanged(object sender, EventArgs e)
    {
        if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                var text = e.Text;
                int num;
    
                var success = int.TryParse(text, out num);
                if (!success)
                    return;
    
                if (num <= 20)
                {
                    if (
                        MessageBox.Show("Are you sure you want to go underneath 20?",
                            "... You sure?", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) ==
                        MessageBoxResult.Yes)
                        e.Handled = true;
                    else
                    {
                        num++;
                        textBox.Text = num.ToString();
                    }
                }
    
                e.Handled = true;
            }
        }
