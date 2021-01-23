    protected void TextBoxPredictDays_TextChanged(object sender, EventArgs e)
            {
                string selectPredictDays = DropDownList1.SelectedItem.Value;
                if (selectPredictDays == "Days")
                {
                    TextBoxPredictedClosing.Text = DateTime.Now.AddDays(Convert.ToInt32(TextBoxPredictDays.Text));
                }
                else if (selectPredictDays == "Weeks")
                {
                    TextBoxPredictedClosing.Text = DateTime.Now.AddDays(Convert.ToInt32(TextBoxPredictDays.Text) * 7);
                }
                else if (selectPredictDays == "Months")
                {
                    TextBoxPredictedClosing.Text = DateTime.Now.AddMonths(Convert.ToInt32(TextBoxPredictDays.Text));
                }
            }
