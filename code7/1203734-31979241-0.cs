    bool validInput = false;
    int inputValue = 0;
    try {
        inputValue = Int32.Parse(TextBox6.Text);
        validInput = true;
    }
    catch {
        validInput = false;
    }
    if (TextBox6.Text != null && validInput && inputValue <= int.MaxValue)
