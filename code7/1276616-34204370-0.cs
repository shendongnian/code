        protected void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {  
            if (cb1.SelectedValue != string.Empty && cb2.SelectedValue != string.Empty)
            {
                fillTextBox(cb1.SelectedValue, cb2.SelectedValue);
            }
        }
        protected void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb1.SelectedValue != string.Empty && cb2.SelectedValue != string.Empty)
            {
                fillTextBox(cb1.SelectedValue, cb2.SelectedValue);
            }
        }
        private void fillTextBox(string value1, string value2)
        {
            tb1.Text = (Convert.ToInt32(value1) / Convert.ToInt32(value2)).ToString();
        }
