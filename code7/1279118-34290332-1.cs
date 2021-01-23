    static class Program
    {
        [STAThread]
        static void Main()
        {
            var kh = new KeyboardHook(true);
            kh.KeyDown += Kh_KeyDown;
            Application.Run();
        }
        private static void Kh_KeyDown(Keys key, bool Shift, bool Ctrl, bool Alt)
        {
            Debug.WriteLine("The Key: " + key);
        }
    }
