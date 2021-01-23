    TextBox test = new TextBox();
    test.IsKeyboardFocusedChanged += test_IsKeyboardFocusedChanged;
    void test_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        var test = sender as TextBox;
        test.Text = Regex.Replace(test.Text, "[^0-9.]", "");
    }
