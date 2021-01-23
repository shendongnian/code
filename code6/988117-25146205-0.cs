            private void TB_Fahrenheit_KeyPress(object sender, KeyPressEventArgs e)
        {
            float C, F;
            if (TB_Fahrenheit.Text != "")
            {
                if (float.Parse(TB_Fahrenheit.Text) < 1.0F)
                {
                    TB_Fahrenheit.Text = "0" + TB_Fahrenheit.Text;
                }
                F = float.Parse(TB_Fahrenheit.Text);
                C = ((F - 32) * 5) / 9;
                TB_Celcius.Text = C.ToString();
            }
        }
        private void TB_Celcius_KeyPress(object sender, KeyPressEventArgs e)
        {
            float C, F;
            string SentBy = ((TextBox)sender).Name;
            if (TB_Celcius.Text != "")
            {
                if (float.Parse(TB_Celcius.Text) < 1.0F)
                {
                    TB_Celcius.Text = "0" + TB_Celcius.Text;
                }
                C = float.Parse(TB_Celcius.Text);
                F = ((C * 9) / 5) + 32;
                TB_Fahrenheit.Text = F.ToString();
            }
        }
