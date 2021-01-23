    if(m.Msg == WM_HOTKEY)
    {
        var param = (int)m.WParam;
        switch(param)
        {
            case 1:
                Console.WriteLine("w");
                break;
                ....
        }
    }
