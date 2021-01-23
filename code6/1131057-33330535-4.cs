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
        static IEnumerable<char> GetKeyboardLayoutCharacters(IntPtr keyboardLayout)
        {
            return
                Enumerable.Range(32, char.MaxValue - 32)
                    .Select(n => (char)n)
                    .Where(c => IsRepresentable(c, keyboardLayout));
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var layout = Api.GetKeyboardLayout(Api.GetCurrentThreadId());
            Console.WriteLine(string.Concat(GetKeyboardLayoutCharacters(layout)));
        }
    }
