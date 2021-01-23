    if(m.Msg == WM_HOTKEY)
    {
        switch ((int)m.WParam)
        {
            case 1:
                Console.WriteLine("w");
                break;
            case 2:
                Console.WriteLine("a");
                break;
            case 3:
                Console.WriteLine("s");
                break;
            case 4:
                Console.WriteLine("d");
                break;
        }
    }
