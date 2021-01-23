        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] keyState);
        private static readonly byte[] DistinctVirtualKeys = Enumerable.Range(0, 256).Select(KeyInterop.KeyFromVirtualKey)
            .Where(item => item != Key.None && item != Key.Enter).Distinct().Select(item => (byte)KeyInterop.VirtualKeyFromKey(item)).ToArray();
        public int GetDownKeysCount()
        {
            var keyboardState = new byte[256];
            GetKeyboardState(keyboardState);
            var downKeyBytes = DistinctVirtualKeys.ToList().FindAll(virtualKey => (keyboardState[virtualKey] & 0x80) != 0);
            return downKeyBytes.Count;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.KeyboardDevice.Modifiers == ModifierKeys.None && GetDownKeysCount() == 0)
            {
                MessageBox.Show("Enter is pressed");
            }
        }
