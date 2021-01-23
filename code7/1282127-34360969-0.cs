        string message = "";
        if(textBoxNewName.TextLength < 1)
        {
            message += "Please enter a train name!\n"
        }
        if (textBoxNewWidth.TextLength < 1)
        {
            message += "Please enter a train width!\n";
        }
        //  ...etc....
        if (!String.IsNullOrWhiteSpace(message))
        {
            MessageBox.Show(message);
        }
