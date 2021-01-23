    private char[] buttonChars = {'/','*', '+'/*e.t.c*/}
    void buttonFunction(){
        string buttonPressedStr = myButton.Content.ToString();
        char buttonPressed = buttonPressedStr[0];
        int pos = Array.IndexOf(buttonChars , buttonPressed);
        if (pos > -1)
        {
            if (tbxSum.Text.Length > 0){
                char last = tbxSum.Text[tbxSum.Text.Length - 1];
                pos = Array.IndexOf(buttonChars , last);
            }
            else
                pos = 0;
            if (pos > -1){
                tbkSum.Text += buttonPressedStr;
            }
    }
