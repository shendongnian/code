    ...
    NumberRestrictFunction();
    ...
    public void NumberRestrictFunction()
    {
        textBox.PreviewTextInput += new TextCompositionEventHandler(MyNumbers_PreviewTextInput);
    }
    
    public static void MyNumbers_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        e.Handled = CheckIfMyCharacters(e.Text);
    }
    public static bool CheckIfMyCharacters(String text)
    {
        Regex regex = new Regex(@"[1-4.]+");  
        return !regex.IsMatch(text);
    }
