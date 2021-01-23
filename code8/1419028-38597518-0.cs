        private double _CursorInterval;
        /// <summary>
        /// Values below 500ms not recommended, due to safety hazards on epilepsy.
        /// </summary>
        public double CursorInterval
        {
            get { return _CursorInterval; }
            set { _CursorInterval = value; }
        }
        private bool blink = false;
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Height = TextRenderer.MeasureText("A", Font).Height + (2 * BorderWidth) + (2 * TextPadding);
            _InputBounds = new Rectangle(BorderWidth + TextPadding, BorderWidth + TextPadding, Width - (2 * BorderWidth) - (2 * TextPadding), Height - (2 * BorderWidth) - (2 * TextPadding));
            if (blink)
                e.Graphics.FillRectangle(new SolidBrush(BorderColor), new Rectangle(_InputBounds.Location, new Size(1, _InputBounds.Height)));
        }
        System.Timers.Timer blinkTimer;
        protected override void OnGotFocus(EventArgs e)
        {
            if (!DesignMode)
            {
                blinkTimer = new System.Timers.Timer(CursorInterval);
                blinkTimer.Elapsed += TimerElapsed;
                blinkTimer.Start();
                Console.WriteLine("OnGotFocus - I was here.");
            }
            blink = true;
            Invalidate();
            base.OnGotFocus(e);
        }
        private void TimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            blink = !blink;
            Console.WriteLine("TimerElapsed - I was here.");
            Invalidate();
        }
        protected override void OnLostFocus(EventArgs e)
        {
            if(!DesignMode)
            {
                blink = false;
                blinkTimer.Stop();
                blinkTimer.Elapsed -= TimerElapsed;
                Console.WriteLine("OnLostFocus - I was here.");
            }
            Invalidate();
            base.OnLostFocus(e);
        }
        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);
            Focus();
        }
