    while (TOGGLE == false)
    {
        if (Keyboard.IsKeyDown(Key.A)) { RESULT = RESULT + "A"; System.Threading.Thread.Sleep(100); }
        if (Keyboard.IsKeyDown(Key.B)) { RESULT = RESULT + "B"; MessageBox.Show(RESULT); }
        if (Keyboard.IsKeyDown(Key.C)) { RESULT = RESULT + "C"; MessageBox.Show(RESULT); }
    }
