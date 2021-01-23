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
        else
        {
            NewName = textBoxNewName.Text;
            //  ...and so on for the other five properties. 
            //  This will close the form and cause ShowDialog() to
            //  return DialogResult.OK
            DialogResult = DialogResult.OK;
        }
