    class OnOffButton : Button
    {
        bool on = true;
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(this.BackColor);
            pevent.Graphics.DrawRectangle(Pens.Blue, 0, 0, 85, 25);
            if (on)
            {
                pevent.Graphics.DrawString("ON", new Font("Microsoft sans serif", 8, FontStyle.Bold), Brushes.Black, 5, 5);
                pevent.Graphics.FillRectangle(Brushes.Gray, 50, 1, 35, 24);
            }
            else
            {
                pevent.Graphics.DrawString("OFF", new Font("Microsoft sans serif", 8, FontStyle.Bold), Brushes.Black, 50, 5);
                pevent.Graphics.FillRectangle(Brushes.Gray, 1, 1, 35, 24);
            }
        }
        protected override void OnClick(EventArgs e)
        {
            on = !on;
            Invalidate();
        }
        public bool On { get { return on; } }
    }
