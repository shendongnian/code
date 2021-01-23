    using System;
    using System.Drawing;
    using System.Windows.Forms;
    public class GlowButton : Button
    {
        Timer timer;
        int alpha = 0;
        public Color GlowColor { get; set; }
        public GlowButton()
        {
            this.DoubleBuffered = true;
            timer = new Timer() { Interval = 50 };
            timer.Tick += timer_Tick;
            this.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.GlowColor = Color.Gold;
            this.FlatAppearance.MouseDownBackColor = Color.Gold;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.FlatAppearance.MouseOverBackColor = CalculateColor();
            timer.Start();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            timer.Stop();
            alpha = 0;
            this.FlatAppearance.MouseOverBackColor = CalculateColor();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            int increament = 25;
            if (alpha + increament < 255) { alpha += increament; }
            else { timer.Stop(); alpha = 255; }
            this.FlatAppearance.MouseOverBackColor = CalculateColor();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing) timer.Dispose();
            base.Dispose(disposing);
        }
        private Color CalculateColor()
        {
            return AlphaBlend(Color.FromArgb(alpha, GlowColor), this.BackColor);
        }
        public Color AlphaBlend(Color A, Color B)
        {
            var r = (A.R * A.A / 255) + (B.R * B.A * (255 - A.A) / (255 * 255));
            var g = (A.G * A.A / 255) + (B.G * B.A * (255 - A.A) / (255 * 255));
            var b = (A.B * A.A / 255) + (B.B * B.A * (255 - A.A) / (255 * 255));
            var a = A.A + (B.A * (255 - A.A) / 255);
            return Color.FromArgb(a, r, g, b);
        }
    }
