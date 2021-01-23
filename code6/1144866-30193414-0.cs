    public class MyMessageBox {
        public virtual DialogResult Show(string text, string caption, MessageBoxButtons buttons) {
            return MessageBox.Show(text, caption, buttons);
        }
    }
