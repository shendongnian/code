    private static async void Strum()
    {
        var inputs = new[]
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
            },
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
            SendInput((uint)inputs.Length, inputs, INPUT.Size);
        }
    }
