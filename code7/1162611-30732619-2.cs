    MenueButton button1 = CreateButton("Button 1 Text");
    button1.Click+=... 
    MenueButton button2 = CreateButton("XYZ");
 
    MenueButton CreateButton(string buttonText)
    {
        MenueButton b= new MenueButton();
        b.Text = buttonText;
        panel.Controls.Add(b);
        return b;
    }
