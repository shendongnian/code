    private bool ValidateTextBox(TextBox tb, double save, out double valueToAssign, double compareTo, bool greaterThan)
    {
        tb.BackColor = Color.Tomato;
        if (!Double.TryParse(tb.Text, out valueToAssign))
        {
            valueToAssign = save;
            return false;
        }
        if (greaterThan && (valueToAssign >= compareTo) || !greaterThan && (valueToAssign <= compareTo))
        {
            tb.BackColor = Color.White;
            return true;
        }
        else
        {
            //Rollback
            valueToAssign = save;
            return false;
        }
    }
    private void ValidateAll()
    {
        btnOk.Enabled = 
            ValidateTextBox(tbMax, Max, out Max, Min, true) &
            ValidateTextBox(tbMin, Min, out Min, Max, false) &
            ValidateTextBox(tbMajStep, MajorStep, out MajorStep, MinorStep, true) &
            ValidateTextBox(tbMinStep, MinorStep, out MinorStep, MajorStep, false);
    }
