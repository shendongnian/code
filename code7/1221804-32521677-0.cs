    private string FunctionChar(Keys e)
            {
    
                if ((int)e >= 65 && (int)e <= 90)
                {
    
                    if (Control.IsKeyLocked(Keys.CapsLock) || ((Control.ModifierKeys != 0) && (Keys.Shift) != 0))
                    {
                        return ((char)e).ToString();
                    }
                    else
                    {
                        return ((char)e).ToString().ToLower();
                    }
                }
                return "";
            }
