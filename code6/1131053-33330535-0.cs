    public class Api
    {
        [DllImport("kernel32.dll")]
        public static extern uint GetCurrentThreadId();
        [DllImport("user32.dll")]
        public static extern IntPtr GetKeyboardLayout(uint idThread);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern short VkKeyScanEx(char ch, IntPtr dwhkl);
    }
    class Program
    {
        static bool IsRepresentable(char c, IntPtr keyboardLayout)
        {
            var x = Api.VkKeyScanEx(c, keyboardLayout);
            return x != -1;
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var layout = Api.GetKeyboardLayout(Api.GetCurrentThreadId());
            for (int i = 0; i < 65535; i++)
            {
                var c = (char)i;
                if (IsRepresentable(c, layout) && char.IsLetter(c))
                    Console.Write(c);
            }
        }
    }
