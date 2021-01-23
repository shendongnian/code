    string valueText = ""; // The sequence of numbers you've entered. Ex. 1 0 0 0 0
    // This ensures that the textbox allways shows something like "0,00"
    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        string inputText = ""; // The text to print in textbox
        if (valueText.Length < 3) // If there are under 3 numbers in the number you've entered, add zeros before the number. Ex. if you've entered: 1 0 , then the box should print "0,10". Therefore, add the zeros if the value text's length is below 3
        {
            for (int zeros = 0; zeros < 3 - valueText.Length; zeros++)
                inputText += "0";
        }
        inputText += valueText; // Append the numbers you've entered
        textBox1.Text = inputText.Insert(inputText.Length - 2, ","); // insert the comma two positions from the right end
    }
    private void textBox1_KeyDown(object sender, KeyEventArgs e)
    {
        List<Keys> keys = new List<Keys>() { Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0 }; // The keys you can press to enter a number
        if (keys.Contains(e.KeyCode)) // If the key you pressed is "accepted"
        {
            valueText += e.KeyCode.ToString().Replace("D", ""); // the key "1" will be "D1", therefore, remove the "D"
        }
        else if (e.KeyCode == Keys.Back) // If backspace is pressed
        {
            if (valueText.Length > 0)
                valueText = valueText.Remove(valueText.Length - 1, 1); // Remove the last number Ex. 1,00 + backspace = 0,10
        }
        textBox1_TextChanged(null, EventArgs.Empty); // Update the text in the textBox
    }
