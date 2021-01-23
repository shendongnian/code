        protected override void WndProc(ref Message m) {
            // Prevent validation on close:
            if (m.Msg == 0x10) this.AutoValidate = AutoValidate.Disable;
            base.WndProc(ref m);
        }
