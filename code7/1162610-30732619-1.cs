     MenueButton button1 = CreateButton();
     button1.Click+=...
     MenueButton button2 = CreateButton();
     button2.Text="ABC";
     MenueButton CreateButton()
     {
       MenueButton b= new MenueButton();
       panel.Controls.Add(b);
       return b;
     }
