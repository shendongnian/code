    const int WM_KEYDOWN = 0x0101;
    const int WM_KEYUP = 0x0100;
    bool keyToCheckDown = false;
    protected override bool ProcessKeyPreview(ref Message m) 
    {
        int msgVal = m.WParam.ToInt32();
        if (m.Msg == WM_KEYDOWN)
        {
            if ((Keys)msgVal == KEY_TO_CHECK)
                keyToCheckDown = true;
            switch((Keys)msgVal) {
            case Keys.W:
                Console.WriteLine("W being held");
                break;
            case Keys.A:
                Console.WriteLine("A being held");
                break;
            }
            // the second condition is necessary so that you don't "return true" the when the key to check is pressed.
            if (keyToCheckDown && (Keys)msgVal != KEY_TO_CHECK)
                return true;
        }
        if (m.Msg == WM_KEYUP) {
            switch((Keys)msgVal) {
                case Keys.W:
                    Console.WriteLine("W released");
                    break;
                case Keys.A:
                    Console.WriteLine("A released");
                    break;
            }
            if ((Keys)msgVal == KEY_TO_CHECK)
                keyToCheckDown = false;
        } 
    
        return base.ProcessKeyPreview(ref m);
    }
