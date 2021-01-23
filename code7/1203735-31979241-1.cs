    bool validInput = false;
    try {
        Int32.Parse(TextBox6.Text);
        validInput = true;
    }
    catch {
    }
    if (TextBox6.Text != null && validInput)
