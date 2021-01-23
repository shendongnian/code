    //Looping
    bool textChar = false;
    foreach(char letter in NumberTextBoxInput)
    {
        if(!Char.IsNumber(letter))
        {
            textChar = true;
            break;
        }
    }
    if(textChar)
        MessageBox.Show("Please enter a valid number.");
    else
    {
        //Rest of method
    }
