    double number1, number2, ans; // Identify variables as double to account for decimals.
    number1 = Convert.ToDouble(num1.Text); // Convert the contents of the textBox into a double.
    number2 = Convert.ToDouble(num2.Text); // 
    ans = 0.0;
    string symbol = modifier1.Text;
    if (symbol == "/" && number2 == 0) // This part seems to be broken.
    {
        answer.Text = "Invalid input.";
    }
    else 
    {
        if (symbol == "+")
        {
            ans = number1 + number2;
        }
        else if (symbol == "-")
        {
            ans = number1 - number2;
        }
        else if (symbol == "/")
        {
            ans = number1 / number2;
        }
        else if (symbol == "*")
        {
            ans = number1 * number2;
        }
        else
        {
            ans = 0;
        }
        answer.Text = ans.ToString("n"); // Change label value to a number.
    }
