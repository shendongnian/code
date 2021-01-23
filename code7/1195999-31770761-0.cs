    _logBox = new InputConsoleBox(0, 0, (short)Console.BufferWidth, (short)(Console.BufferHeight - 2), InputConsoleBox.Colors.LightWhite, InputConsoleBox.Colors.Black);
    _logBox.AutoRedraw = false;
    _statusBox = new InputConsoleBox(0, (short)(Console.BufferHeight - 3), (short)Console.BufferWidth, 1, InputConsoleBox.Colors.LightYellow, InputConsoleBox.Colors.DarkBlue);
    _inputBox = new InputConsoleBox(0, (short)(Console.BufferHeight - 2), (short)Console.BufferWidth, 1, InputConsoleBox.Colors.LightYellow, InputConsoleBox.Colors.Black);
    _statusBox.WriteLine("Hey there!");
    _inputBox.InputPrompt = "Command: ";
    // Write these in a separate thread / event from logger / etc...
    _logBox.WriteLine("Write all the log lines using this"); 
    // Do this every 200ms or so
    _logBox.Draw();
    
    // Line input box
    var line = _inputBox.ReadLine(); // Blocking while waiting for <enter>
