     private static bool _intercept = true;
     private static IntPtr HookCallback(
            int nCode, IntPtr wParam, IntPtr lParam)
     {
          if (_intercept)
          {
               if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
               {
                   int vkCode = Marshal.ReadInt32(lParam);
                   if (vkCode == 160 || vkCode == 161) { shift = 1; }
                   if (vkCode == 162 || vkCode == 163) { ctrl = 1; }
                   if (vkCode == 164 || vkCode == 165) { alt = 1; }
                   Console.WriteLine(vkCode + "_" + shift);
                   int res = replaceKey.getReplacedKey(vkCode, shift);
                   if (res != -1 && ctrl == 0 && alt == 0 && getCurrentKeyboardLangauge().Contains("Hebrew"))
                   {
                       try
                       {
                           _intercept = false; // Stop listening keystroke for the next key
                           SendKeys.SendWait(char.ConvertFromUtf32((int)res));
                       }
                       catch (Exception ex)
                       {
                           Debug.Print(ex.Message);
                       }
                       finally
                       {
                           _intercept = true; // Reactivate listening keystroke for the next key
                       }
                       return (System.IntPtr)1;
                   }
                   else if (getCurrentKeyboardLangauge().Contains("Hebrew") && (vkCode == 79 || vkCode == 89 || vkCode == 69 || vkCode == 81 || vkCode == 220 || vkCode == 77 || vkCode == 78 || vkCode == 66 || vkCode == 76 || vkCode == 88 || vkCode == 90 || vkCode == 226))
                   {
                       return (System.IntPtr)1;
                   }
               }
               else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
               {
                   int vkCode = Marshal.ReadInt32(lParam);
                   //Console.WriteLine(vkCode);
                   if (vkCode == 160 || vkCode == 161) { shift = 0; }
                   if (vkCode == 162 || vkCode == 163) { ctrl = 0; }
                   if (vkCode == 164 || vkCode == 165) { alt = 0; }
               }
           }
           return CallNextHookEx(_hookID, nCode, wParam, lParam);
       }
