    private static async void Strum()
    {
        var keydowns = new[]
        {
            new INPUT
            {
                type = InputType.KEYBOARD,
                U =
                {
                    ki =
                    {
                        wScan = ScanCodeShort.RSHIFT
                    }
                }
            }
        };
        
        var keyups = new[]
        {
            new INPUT
            {
                type = InputType.KEYBOARD,
                U =
                {
                    ki =
                    {
                        wScan = ScanCodeShort.RSHIFT,
                        dwFlags = KEYEVENTF.KEYUP
                    }
                }
            }
        };
            
        for (var i = 0; i < 18; i++)
        {
            SendInput((uint)keydowns.Length, keydowns, INPUT.Size);
            SendInput((uint)keyups.Length, keyups, INPUT.Size);
        }
    }
