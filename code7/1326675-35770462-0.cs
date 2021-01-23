    class ProgrammingTextBox : RichTextBox {
        protected override bool IsInputKey(Keys keyData) {
            if (keyData == Keys.Tab) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e) {
            if (e.KeyCode == Keys.Tab) {
                const string tabtospaces = "    ";
                var hassel = this.SelectionLength > 0;
                this.SelectedText = tabtospaces;
                if (!hassel) this.SelectionStart += tabtospaces.Length;
                e.SuppressKeyPress = true;
            }
            else base.OnKeyDown(e);
        }
    }
