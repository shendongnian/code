    const int WM_KEYDOWN = 0x0101;
    const int WM_KEYUP = 0x0100;
    HashSet<Keys> keysDown = new HashSet<Keys>();
    protected override bool ProcessKeyPreview(ref Message m) 
    {
        int msgVal = m.WParam.ToInt32();
        if (m.Msg == WM_KEYDOWN)
        {
            keysDown.Add((Keys)msgVal);
            switch((Keys)msgVal) {
            case Keys.W:
                Console.WriteLine("W being held");
                break;
            case Keys.A:
                Console.WriteLine("A being held");
                break;
            }
            if (keysDown.Contains(keyToCheck))
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
            keysDown.Remove((Keys)msgVal);
        } 
    
        return base.ProcessKeyPreview(ref m);
    }
