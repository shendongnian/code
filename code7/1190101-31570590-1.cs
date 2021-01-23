        protected override void SetVisibleCore(bool value) {
            if (!this.IsHandleCreated) {
                NativeMethods.AnimateWindow(this.Handle, 100, AnimateWindowFlags.AW_BLEND);
            }
            base.SetVisibleCore(value);
        }
        protected override void OnShown(EventArgs e) {
            this.BringToFront();
            base.OnShown(e);
        }
