        protected override void WndProc(ref Message m)
        {
            int i;
            if (m.Msg == 0x302)
                if (int.TryParse(Clipboard.GetText(), out i))
                {
                    this.SelectedText = Clipboard.GetText();
                    return;
                }
                else return;
            base.WndProc(ref m);
        }
