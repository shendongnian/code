    protected override void WndProc(ref Message m) {
        const int WM_MOUSEACTIVATE = 0x21;
        if (m.Msg == WM_MOUSEACTIVATE) {
            // Take focus to enable click-through behavior for setting selection
            this.Focus();
        }
        // Let the base handle the event.
        base.WndProc(ref m);
    }
