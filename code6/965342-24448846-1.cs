         public void CheckKeyboard() 
          {
            KeyboardCapabilities keyboardCapabilities = new Windows.Devices.Input.KeyboardCapabilities();
            var isKeyboardPresent = keyboardCapabilities.KeyboardPresent != 0 ? true : false;
            if(!isKeyboardPresent)
               ShowKeyboard();
          }
        
          public void ShowKeyboard()
          {
             Path(Environment.SpecialFolder.System) + Path.DirectorySeparatorChar + "osk.exe");
          }
