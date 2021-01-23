    int[] posno={0,0,0,0,0};
    int lastInput = 0;
        private void gobtn_Click(object sender, EventArgs e)
        {
            int input = Int32.Parse(num.Text);
            if (input >= 0)
            {
                posno[lastInput] = input;
                lastInput++;
                //reset counter
                if (lastInput = 5) 
                { 
                    lastInput = 0; 
                }
            }
            no1.Text = posno[0].ToString();
            no2.Text = posno[1].ToString();
            no3.Text = posno[2].ToString();
            no4.Text = posno[3].ToString();
            no5.Text = posno[4].ToString();
        }
