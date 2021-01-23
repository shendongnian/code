    class MyGrid : Control {
        private const int pitch = 32;
    
        protected override void OnClientSizeChanged(EventArgs e) {
            var w = pitch * ((this.ClientSize.Width + pitch/2) / pitch);
            var h = pitch * ((this.ClientSize.Height + pitch/2) / pitch);
            if (w != this.ClientSize.Width || h != this.ClientSize.Height)
                this.ClientSize = new Size(w, h);
            else base.OnClientSizeChanged(e);
        }
    }
