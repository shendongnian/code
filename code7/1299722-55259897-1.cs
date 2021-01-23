    public static class KeyboardHelper
    {
            public static ReplyKeyboardMarkup GetKeyboard(List<string> keys)
            {
                var rkm = new ReplyKeyboardMarkup();
                var rows = new List<KeyboardButton[]>();
                var cols = new List<KeyboardButton>();
                foreach (var t in keys)
                {
                    cols.Add(new KeyboardButton(t));
                    rows.Add(cols.ToArray());
                    cols = new List<KeyboardButton>();
                }
                rkm.Keyboard = rows.ToArray();
                return rkm;
            }
    }
