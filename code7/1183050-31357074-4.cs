        protected override void OnLoad(EventArgs e) {
            base.OnLoad(e);
            subClassChildren(this.Controls);
        }
        private void subClassChildren(Control.ControlCollection ctls) {
            foreach (Control ctl in ctls) {
                var rc = this.RectangleToClient(this.RectangleToScreen(ctl.DisplayRectangle));
                if (rc.Left < edge || rc.Right > this.ClientSize.Width - edge ||
                    rc.Top < edge || rc.Bottom > this.ClientSize.Height - edge) {
                    new MouseFilter(this, ctl);
                }
                subClassChildren(ctl.Controls);
            }
        }
