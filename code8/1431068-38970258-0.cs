        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetKeyboardState(byte[] keyState);
        private static readonly byte[] DistinctVirtualKeys = Enumerable.Range(0, 256).Select(KeyInterop.KeyFromVirtualKey)
            .Where(item => item != Key.None && item != Key.Enter).Distinct().Select(item => (byte)KeyInterop.VirtualKeyFromKey(item)).ToArray();
        public IEnumerable<Key> GetDownKeys()
        {
            var keyboardState = new byte[256];
            GetKeyboardState(keyboardState);
            var downKeys = new List<Key>();
            for (var index = 0; index < DistinctVirtualKeys.Length; index++)
            {
                var virtualKey = DistinctVirtualKeys[index];
                if ((keyboardState[virtualKey] & 0x80) != 0)
                {
                    downKeys.Add(KeyInterop.KeyFromVirtualKey(virtualKey));
                }
            }
            return downKeys;
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.KeyboardDevice.Modifiers == ModifierKeys.None && GetDownKeys().Count() == 0)
            {
                MessageBox.Show("Enter is pressed");
            }
        }
