    private void SomeTextBox_KeyDown(object sender, KeyEventArgs e)
    {
        if(e.Key == Key.Enter)
        {
             this.Focus(); // dismiss the keyboard
             // Call the submit method here
        }
    }
