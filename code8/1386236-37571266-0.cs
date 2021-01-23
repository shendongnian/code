            private bool verifyUI()
            {
                bool alluserInputsOk = true;
                foreach (Control cTxt in Controls.OfType<TextBox>())
                {
                    if (string.IsNullOrWhiteSpace(cTxt.Text))
                    {
                        userInputOk = false;
                        break;
                    }                   
                }
                return userInputOk;
            }
