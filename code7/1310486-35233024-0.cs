        //If pressed w or W
        case (char)119:
        case (char)87:
                Console.WriteLine(e.KeyChar);
                button1.BackColor = Color.Red;//Highlight W
                button2.BackColor = Color.Empty;//Ignore A
                button3.BackColor = Color.Empty;//Ignore S
                button3.BackColor = Color.Empty;//Ignore D
                break;
