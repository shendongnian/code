    private void maskedTextBox1_Validating_1(object sender, CancelEventArgs e) {
        // Stop when empty (avoiding the user getting "locked" in the box)
        if (maskedTextBox1.Text.Length == 0) return;
        // Validate text, cancel when not valid and show error to user
        if (maskedTextBox1.Text.Length < 4 || maskedTextBox1.Text.Length > 15) {
            e.Cancel = true;
            MessageBox.Show("Please enter a text of 4 - 15 characters length!");
        }
    }
