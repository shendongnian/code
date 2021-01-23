    bool TryConvert(TextBox textBox, out double value)
    {
        if (!Double.TryPare(textBox.Text, out value)) {
            string message = String.Format("Invalid {0} entered.", textBox.Name.ToLower());
            MessageBox.Show(message , "Volume Calculator", MessageBoxButtons.OK,
                            MessageBoxIcon.Warning);
            textBox.Focus();
            textBox.SelectAll();
            return false;
        }
        return true;
    }
