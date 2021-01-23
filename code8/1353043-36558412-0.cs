                textBox2.Text = "your username is " + username + "\n";
                textBox2.Text += "You last logged off on " + ConvertUnix(LastLogOff) + "\n";
                if (PrivacyLevel == 3)
                {
                    textBox2.Text += "This user's account is public"; 
                }
                else if (PrivacyLevel == 1)
                {
                    textBox2.Text += "This user's account is private";
                }
                switch (CurrentStatus)
                {
                    case 1:
                        textBox2.Text += "This user is offline";
                        break;
                    case 2:
                        textBox2.Text += "This User is online and playing";
                        break;
                }
            }
            else
            {
                textBox2.Text += "You have entered the SteamID incorrectly";
            }
