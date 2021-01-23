     panel1.Controls.Clear();
     for (int i = 1; i < 5; i++)
     {
         Button button = new Button();
         button.Name = "Button" + i;
         button.Tag = "PLCVar" + i;
         button.MouseUp += button_JogPLCVar_MouseUp;
         button.MouseDown += button_JogPLCVar_MouseDown;
         panel1.Controls.Add(button);
     }
