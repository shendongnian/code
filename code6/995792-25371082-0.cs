    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
 
    public class CapsLockControl
    {
        [DllImport("user32.dll")]
        static extern void keybd_event(byte bVk, byte bScan, uint dwFlags,UIntPtr dwExtraInfo);
        const int KEYEVENTF_EXTENDEDKEY = 0x1;
        const int KEYEVENTF_KEYUP = 0x2;
 
    public static void Main()
    {
        if (Control.IsKeyLocked(Keys.CapsLock))
            {
                Console.WriteLine("Caps Lock key is ON.  We'll turn it off");
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY, (UIntPtr) 0);
                keybd_event(0x14, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP,
                (UIntPtr) 0);
            }
        else
            {
                Console.WriteLine("Caps Lock key is OFF");
            }
        }
    }
