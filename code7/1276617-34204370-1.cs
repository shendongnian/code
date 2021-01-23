        //event triggered when SelectedIndexChanged
        protected void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            int b;
            //In this way you can compare the value and if it is possible to convert into an integer. 
            if (int.TryParse(cb1.SelectedValue, out a) && int.TryParse(cb2.SelectedValue, out b))
            {
                fillTextBox(a, b);
            }
        }
        protected void cb2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int a;
            int b;
            if (int.TryParse(cb1.SelectedValue, out a) && int.TryParse(cb2.SelectedValue, out b))
            {
                fillTextBox(a,b);
            }
        }
        private void fillTextBox(int value1, int value2)
        {
            tb1.Text = (value1 / value2).ToString();
        }
