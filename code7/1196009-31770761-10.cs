    _logBox = new InputConsoleBox(0, 0, (short)Console.BufferWidth, (short)(Console.BufferHeight - 2), InputConsoleBox.Colors.LightWhite, InputConsoleBox.Colors.Black);
    _statusBox = new InputConsoleBox(0, (short)(Console.BufferHeight - 3), (short)Console.BufferWidth, 1, InputConsoleBox.Colors.LightYellow, InputConsoleBox.Colors.DarkBlue);
    _inputBox = new InputConsoleBox(0, (short)(Console.BufferHeight - 2), (short)Console.BufferWidth, 1, InputConsoleBox.Colors.LightYellow, InputConsoleBox.Colors.Black);
    _statusBox.WriteLine("Hey there!");
    _inputBox.InputPrompt = "Command: ";
    // If you are okay with some slight flickering this is an easy way to set up a refresh timer
    _logBox.AutoDraw = false;
    _redrawTask = Task.Factory.StartNew(async () =>
    {
        while (true)
        {
            await Task.Delay(100);
            if (_logBox.IsDirty)
                _logBox.Draw();
        }
    });
    // Line input box
    var line = _inputBox.ReadLine(); // Blocking while waiting for <enter>
