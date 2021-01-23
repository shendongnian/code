        public static string GetBuffKeys()
        {
            var allModifierKeys = new Dictionary<Keys, Keys> { { Keys.ControlKey, Keys.Control }, {Keys.ShiftKey, Keys.Shift}, {Keys.Menu, Keys.Alt }};
            var modifiers = Control.ModifierKeys;
            string buffer = "";
            foreach (var key in Enum.GetValues(typeof(Keys)).OfType<Keys>().Distinct()) // The enum seems to have duplicated values for Enter and Return.  Uniquify them.
            {
                if (GetAsyncKeyState((int)key) == -32767)
                {
                    buffer += ReplaceChars(Enum.GetName(typeof(Keys), key));
                    if (allModifierKeys.Keys.Contains(key))
                        modifiers &= ~(allModifierKeys[key]); // Remove this modifier to prevent double printing.
                }
            }
            if (modifiers != Keys.None)
            {
                buffer = buffer + " [" + modifiers.ToString() + "]";
            }
            return buffer;
        }
