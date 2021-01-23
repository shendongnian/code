        private static void Animate(Control ctl, Image img, int[] delays) {
            int frame = 0;
            var tmr = new Timer() { Interval = delays[0], Enabled = true };
            tmr.Tick += delegate {
                frame++;
                if (frame >= delays.Length) frame = 0;
                img.SelectActiveFrame(FrameDimension.Page, frame);
                tmr.Interval = delays[frame];
                ctl.Invalidate();
            };
            ctl.Disposed += delegate { tmr.Dispose(); };
        }
