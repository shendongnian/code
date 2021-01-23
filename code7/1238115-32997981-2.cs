    private void CreateButton_Click(object sender, RoutedEventArgs e)
            {
                if (!string.IsNullOrEmpty(StringTextBox.Text))
                {
                    MVVMList.Instance.Onglets.Add(StringTextBox.Text);
                }
            }
