    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // to check :
        MessageBox.Show(StudentManagements[1].StudentID.ToString());
        var textboxes = AccessGrid.FindAllVisualDescendants()
            .Where(elt => elt.Name == "StudentIdTextBox" )
            .OfType<TextBox>();
        foreach (var textbox in textboxes)
        {
            BindingExpression binding = textbox.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }
        // to check :
        MessageBox.Show(StudentManagements[1].StudentID.ToString());
    }
