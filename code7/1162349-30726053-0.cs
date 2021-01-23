     int counter = 0;
            int numberOfTextBoxtoShow = 4; // set by user
            foreach (Control c in Panel1.Controls)
            {
                if (c is TextBox)
                {
                    if (counter < numberOfTextBoxtoShow)
                    {
                        c.Visible = true;
                        counter++;
                    }
                    else c.Visible = false;
                }
           }
