    while (TOGGLE == false) 
    {
        if (Keyboard.IsKeyDown(Key.A)) 
        { 
            RESULT = RESULT + "A";
            TOGGLE = true;
        }
        if (Keyboard.IsKeyDown(Key.B)) 
        { 
            RESULT = RESULT + "B"; 
            MessageBox.Show(RESULT);
            TOGGLE = true;
        }
        if (Keyboard.IsKeyDown(Key.C)) 
        {
            RESULT = RESULT + "C"; 
            MessageBox.Show(RESULT); 
            TOGGLE = true;
        }
    }
