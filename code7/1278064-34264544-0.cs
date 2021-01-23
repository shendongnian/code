    class SelectablePanel : Panel
    {
        public SelectablePanel()
        {
            this.SetStyle(ControlStyles.Selectable, true);
            this.TabStop = true;
        }
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Up || keyData == Keys.Down) return true;
            if (keyData == Keys.Left || keyData == Keys.Right) return true;
            return base.IsInputKey(keyData);
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            var handler = KeyDown;
            if (handler != null) handler(this, e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            var handler = KeyPress;
            if (handler != null) handler(this, e);
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            var handler = KeyUp;
            if (handler != null) handler(this, e);
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            this.Focus();
            base.OnMouseEnter(e);
        }
        protected override void OnEnter(EventArgs e)
        {
            this.Invalidate();
            base.OnEnter(e);
        }
        protected override void OnLeave(EventArgs e)
        {
            this.Invalidate();
            base.OnLeave(e);
        }
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (this.Focused)
            {
                var rc = this.ClientRectangle;
                rc.Inflate(-2, -2);
                ControlPaint.DrawFocusRectangle(pe.Graphics, rc);
            }
        }
        public new event EventHandler<KeyEventArgs> KeyDown;
        public new event EventHandler<KeyEventArgs> KeyUp;
        public new event EventHandler<KeyPressEventArgs> KeyPress;
    }
