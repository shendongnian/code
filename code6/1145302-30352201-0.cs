    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace System.Windows.Forms
    {
        public class MenuItemEx : MenuItem
        {
            public MenuItemEx()
            {
            }
            private Keys myShortcut = Keys.None;
            public new Keys Shortcut
            {
                get { return myShortcut; }
                set { myShortcut = value; UpdateShortcutText(); }
            }
            private string myText = string.Empty;
            public new string Text
            {
                get { return myText; }
                set
                {
                    myText = value;
                    UpdateShortcutText();
                }
            }
            private void UpdateShortcutText()
            {
                base.Text = myText;
                if (myShortcut != Keys.None)
                    base.Text += "\t" + myShortcut.ToString(); // you can adjust that
            }
        }
    }
