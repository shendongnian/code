        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int month, day;
            if (int.TryParse(txtMOB.Text, out month) && int.TryParse(txtDOB.Text, out day))
            {
                if(month >= 1 && month <= 12 && day >= 1 && day <=31)
                {
                    lblAlias.Content = ((ListBoxItem)lstBox1.Items[month - 1]).Content.ToString()
                        + " " + ((ListBoxItem)lstBox2.Items[day - 1]).Content.ToString();
                }
                else
                {
                    MessageBox.Show("Month must be between 1 and 12, and Day must be between 1 and 31!");
                }
            }
            else
            {
                MessageBox.Show("Invalid Month and/or Day!");
            }
        }
