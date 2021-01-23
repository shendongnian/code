    private string validOperators = "+-*/";
    public bool IsOperator(TextBox textbox, string name)
    {
        if (!validOperator.Contains(name))
        {
            MessageBox.Show(name + " Must be +, -, *, or /.", "Entry Error");
            txtOperator1.Focus();
            return false;
        }
        return true;
    }
