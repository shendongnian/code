    button.Enabled = false;
    button.Text = "new text";
    Task.Factory.StartNew(() =>
    {
        // do your tasks here and close the window.
        // type your code normally like calling methods. setting variables etc...
        
        StaticVariable = ExampleUsingMethod();
    });
