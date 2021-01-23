    using AutoIt;
    
    class Program
    {
        static void Main(string[] args)
        {
            var text = AutoItX.ControlGetText("Untitled - Notepad", "", "[CLASSNN:Edit1]");
            //In your case, since you are dealing with handles, you can use:
            var windowHandle = new IntPtr(0x00788600);
            var controlHandle = new IntPtr(0x00000000);
            var text2 = AutoItX.ControlGetText(windowHandle, controlHandle);
        }
    }
