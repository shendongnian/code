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
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(alpha, GlowColor);
            this.FlatAppearance.MouseDownBackColor = Color.Gold;
        }
        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            timer.Start();
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            timer.Stop();
            alpha = 0;
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(alpha, Color.Yellow);
        }
        void timer_Tick(object sender, EventArgs e)
        {
            int increament = 15;
            if (alpha + increament < 150)
                alpha += increament;
            else
                timer.Stop();
            this.FlatAppearance.MouseOverBackColor = Color.FromArgb(alpha, GlowColor);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                timer.Stop();
                timer.Dispose();
            }
            base.Dispose(disposing);
        }
    }
