    private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //check for slash press
            if (e.KeyValue == 191)
            {
                //split the input into string array
                string[] input = maskedTextBox1.Text.Split('/');
                //save current cursor position
                int currentpos = maskedTextBox1.SelectionStart;
                // currently entering first date part
                if (currentpos < 3)
                {
                    // add leading 0 if number is less than 10
                    if ((Int32.Parse(input[0]) < 10) && (!input[0].Contains("0")))
                    {
                        input[0] = '0' + input[0];
                        currentpos++;
                    }
                }
                // currently entering second date part
                else if ((currentpos < 6) && (currentpos > 3))
                {
                    // add leading 0 if number is less than 10
                    if ((Int32.Parse(input[1]) < 10) && (!input[1].Contains("0")))
                    {
                        input[1] = '0' + input[1];
                        currentpos++;
                    }
                }
                // currently entering last date part
                else
                {
                    // do nothing here!
                }
                // set masked textbox value to joined array
                maskedTextBox1.Text = String.Join("/",input);
                // adjust the cursor position after setting new textbox value
                maskedTextBox1.SelectionStart = currentpos;
            }
        }
