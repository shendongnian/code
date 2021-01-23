    string Elements = Convert.ToString(txtbElements.Text);
    
        switch (Elements)
        {
            case 1:
            case 2:
            case 3:
                lblElements.Text = string.Format ("A = 1,2,3 ");
                break;
            case 4:
                Console.WriteLine("Case 4");
                break;
            default:
                Console.WriteLine("Default case");
                break;
        }
