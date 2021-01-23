     //HERE IS THE FIX
            //checks whos turn it is and sets the button to X or O
            if (!turn)
            {
                
                //SetControlPropertyValue(btn, "Text", "X");
                if (row == 1 && col == 1)
                {
                    SetControlPropertyValue(button1, "Text", "X");
                    SetControlPropertyValue(button1, "Enabled", false);
                }
                else if (row == 1 && col == 2)
                {
                    SetControlPropertyValue(button2, "Text", "X");
                    SetControlPropertyValue(button2, "Enabled", false);
                }
                else if (row == 1 && col == 3)
                {
                    SetControlPropertyValue(button3, "Text", "X");
                    SetControlPropertyValue(button3, "Enabled", false);
                }
                else if (row == 2 && col == 1)
                {
                    SetControlPropertyValue(button4, "Text", "X");
                    SetControlPropertyValue(button4, "Enabled", false);
                }
                else if (row == 2 && col == 2)
                {
                    SetControlPropertyValue(button5, "Text", "X");
                    SetControlPropertyValue(button5, "Enabled", false);
                }
                else if (row == 2 && col == 3)
                {
                    SetControlPropertyValue(button6, "Text", "X");
                    SetControlPropertyValue(button6, "Enabled", false);
                }
                else if (row == 3 && col == 1)
                {
                    SetControlPropertyValue(button7, "Text", "X");
                    SetControlPropertyValue(button7, "Enabled", false);
                }
                else if (row == 3 && col == 2)
                {
                    SetControlPropertyValue(button8, "Text", "X");
                    SetControlPropertyValue(button8, "Enabled", false);
                }
                else if (row == 3 && col == 3)
                {
                    SetControlPropertyValue(button9, "Text", "X");
                    SetControlPropertyValue(button9, "Enabled", false);
                }
                
            
            }
            else
            {
                //what i was doing before
                //SetControlPropertyValue(btn, "Text", "O");
                if (row == 1 && col == 1)
                {
                    SetControlPropertyValue(button1, "Text", "O");
                    SetControlPropertyValue(button1, "Enabled", false);
                }
                else if (row == 1 && col == 2)
                {
                    SetControlPropertyValue(button2, "Text", "O");
                    SetControlPropertyValue(button2, "Enabled", false);
                }
                else if (row == 1 && col == 3)
                {
                    SetControlPropertyValue(button3, "Text", "O");
                    SetControlPropertyValue(button3, "Enabled", false);
                }
                else if (row == 2 && col == 1)
                {
                    SetControlPropertyValue(button4, "Text", "O");
                    SetControlPropertyValue(button4, "Enabled", false);
                }
                else if (row == 2 && col == 2)
                {
                    SetControlPropertyValue(button5, "Text", "O");
                    SetControlPropertyValue(button5, "Enabled", false);
                }
                else if (row == 2 && col == 3)
                {
                    SetControlPropertyValue(button6, "Text", "O");
                    SetControlPropertyValue(button6, "Enabled", false);
                }
                else if (row == 3 && col == 1)
                {
                    SetControlPropertyValue(button7, "Text", "O");
                    SetControlPropertyValue(button7, "Enabled", false);
                }
                else if (row == 3 && col == 2)
                {
                    SetControlPropertyValue(button8, "Text", "O");
                    SetControlPropertyValue(button8, "Enabled", false);
                }
                else if (row == 3 && col == 3)
                {
                    SetControlPropertyValue(button9, "Text", "O");
                    SetControlPropertyValue(button9, "Enabled", false);
                }
                
            }
