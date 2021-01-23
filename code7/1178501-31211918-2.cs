    DateTime lastAletter = DateTime.Now;
    while (TOGGLE == false)
    {
         if (Keyboard.IsKeyDown(Key.A) && lastAletter.AddMilliseconds(100) < DateTime.Now) { RESULT = RESULT + "A"; lastAletter = DateTime.Now; }
         if (Keyboard.IsKeyDown(Key.B)) { RESULT = RESULT + "B"; MessageBox.Show(RESULT); }
         if (Keyboard.IsKeyDown(Key.C)) { RESULT = RESULT + "C"; MessageBox.Show(RESULT); }
     }
