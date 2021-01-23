    private void ValidateField(TextBox textBox, Label label) {
        
        // check if the textbox actually is null - or empty (""), which is a difference
        // the nifty helper string.IsNullOrEmpty() will help with that
        var fieldIsEmpty = string.IsNullOrEmpty(textBox.Text.Trim());
        // next, based on if the field is empty,  set the visibility of the label
        // don't worry, this is fancy syntax for a simple if...then...else
        label.Visibility = fieldIsEmpty ? Visibility.Visible : Visibility.Hidden;
        if (fieldIsEmpty) {
            // ONLY if this field is actually null, or empty, we make sure to 
            // inform the rest of the code this occ
            HasEmptyFields = true;
        }
    }
