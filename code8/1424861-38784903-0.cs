    public static void SendChar(char c)
        {
            bool und = false;
            if (c == '_')
            {
                und = true;
            }
            int vk = BMDLCommands.VkKeyScan(c);
            int sc = BMDLCommands.MapVirtualKey(vk, 0);
            if(und)
            {
                keysPress(VK_SHIFT, VK_OEM_MINUS);
                MethodInvoker met = delegate
                {
                    keyPress(vk);
                };
            }
            else
            {
                BMDLCommands.PressKeyDn(vk, sc);
                BMDLCommands.ReleaseKeyUp(vk, sc);
            }
        }
