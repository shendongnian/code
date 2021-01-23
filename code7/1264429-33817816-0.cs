    private void txt_p1_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrEmpty(txt_p1.Text)) && (!string.IsNullOrEmpty(txt_p7.Text)))
            {
                int val1, val2;
                //Ensure both are valid integers
                if (int.TryParse(txt_p1.Text, out val1) && int.TryParse(txt_p7.Text, out val2))
                {
                    txt_result.Text = (Convert.ToInt32(txt_p1.Text) - Convert.ToInt32(txt_p7.Text)).ToString();
                }
            }
        }
