        private void btnTotal_Click(object sender, EventArgs e)
        {
            int value;
            int total = 0;
            foreach (TextBox tb in TextBoxes)
            {
                if (int.TryParse(tb.Text, out value))
                {
                    total = total + value;
                }
                else
                {
                    MessageBox.Show(tb.Name + " = " + tb.Text, "Invalid Value");
                }
            }
            MessageBox.Show("total = " + total.ToString());
        }
