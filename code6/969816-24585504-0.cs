    using System;
    using System.Windows.Forms;
    
    class MyComboBox : ComboBox {
        protected override bool IsInputKey(Keys keyData) {
            if ((keyData == Keys.Up) || (keyData == Keys.Down)) return false;
            return base.IsInputKey(keyData);
        }
    }
