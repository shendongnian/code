     bool Upper = true;
            foreach(char c in txtInput.Text)
            {
                if (Upper == true)
                {
                    if (c == ' ')
                    {
                        txtOutput.Text += c;
                        continue;
                    }
                    txtOutput.Text += c.ToString().ToUpper();
                    Upper = false;
                }
                else
                {
                    txtOutput.Text += c;
                }
                if (c == '?' || c == '!' || c == '.')
                    Upper = true;
                
            }
