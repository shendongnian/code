        [DllImport("user32", CharSet = CharSet.Auto,
        ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        static extern short GetKeyState(int keyCode);
        public static bool CheckKeysPressed(params Keys[] keys)
        {
            for (int i = 0; i < keys.Length; i++)
                if (!CheckKeyPressed((int)keys[i])) return false;
            return true;
        }
        public static bool CheckKeyPressed(Keys key)
        {
            return CheckKeyPressed((int)key);
        }
        public static bool CheckKeyPressed(int vkey)
        {
            short ks = GetKeyState(vkey);
            return ks == 1;
        }
