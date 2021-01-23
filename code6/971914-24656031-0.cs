    if (string.IsNullOrEmpty(textBox71.Text))
            {
                MessageBox.Show("please enter date of birth");
            }
            else
            {
    
                DateTime drid2 = Convert.ToDateTime(textBox71.Text);
                DateTime drid3 = DateTime.Now;
                int yy1 = Math.Abs(drid3.Year - drid2.Year);
                textBox72.Text = yy1.ToString();
             }
