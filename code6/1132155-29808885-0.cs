    private static void SendKeysTo(Process proc, string str)
    {
        foreach (var ch in str)
        {
            Key result;
            if (Enum.TryParse<Key>(ch + "", true, out result))
            {
          		PostMessage(proc.MainWindowHandle, WM_KEYDOWN, KeyInterop.VirtualKeyFromKey(result), 0);
            }
        }
    }
