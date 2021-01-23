        void TextBoxOnlyInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '-'))
            {
                e.Handled = true;
            }
            if (e.KeyChar == '-')
                if ((sender as TextBox).Text.Length != (sender as TextBox).SelectionLength)
                    if ((sender as TextBox).Text.Length > 0)
                        e.Handled = true;
        }
        protected override void WndProc(ref Message m)
        {
            int i;
            if (m.Msg == 0x302)
                if (int.TryParse(Clipboard.GetText(), out i))
                {
                    //some restrict to avoid pasted make textbox value become invalid
                    if (i < 0 && this.SelectionStart != 0)
                        return;
                    else if (i < 0 && this.Text[0] == '-')
                        return;
                    else if (this.SelectionStart == 0 && this.Text[0] == '-')
                        return;
                    else
                    {
                        this.SelectedText = Clipboard.GetText();
                        return;
                    }
                }
                else return;
            base.WndProc(ref m);
        }
