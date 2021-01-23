    static class Adorner
    {
        private static List<Control> controls = new List<Control>();
        static public bool AddBadgeTo(Control ctl, string Text)
        {
            if (controls.Contains(ctl)) return false;
            Badge badge = new Badge();
            badge.AutoSize = true;
            badge.Text = Text;
            badge.BackColor = Color.Transparent;
            controls.Add(ctl);
            ctl.Controls.Add(badge);
            SetPosition(badge, ctl);
            return true;
        }
        static public bool RemoveBadgeFrom(Control ctl)
        {
            Badge badge = GetBadge(ctl);
            if (badge != null)
            {
                ctl.Controls.Remove(badge);
                controls.Remove(ctl);
                return true;
            }
            else return false;
        }
        static public void SetBadgeText(Control ctl, string newText)
        {
            Badge badge = GetBadge(ctl);
            if (badge != null) 
            {
                    badge.Text = newText;
                    SetPosition(badge, ctl);
            }
        }
        static public string GetBadgeText(Control ctl)
        {
            Badge badge = GetBadge(ctl);
            if (badge != null) return badge.Text;
            return "";
        }
        static private void SetPosition(Badge badge, Control ctl)
        {
           badge.Location = new Point(ctl.Width - badge.Width - 5, 
                                      ctl.Height - badge.Height - 5);
        }
        static public void SetClickAction(Control ctl, Action<Control> action)
        {
            Badge badge = GetBadge(ctl);
            if (badge != null)  badge.ClickEvent = action;
        }
        static Badge GetBadge(Control ctl)
        {
            for (int c = 0; c < ctl.Controls.Count; c++)
                if (ctl.Controls[c] is Badge) return ctl.Controls[c] as Badge;
            return null;
        }
        class Badge : Label
        {
            Color BackColor = Color.SkyBlue;
            Color ForeColor = Color.White;
            Font font = new Font("Sans Serif", 8f);
            public Action<Control> ClickEvent;
            public Badge()
            {
            }
            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.FillEllipse(new SolidBrush(BackColor), this.ClientRectangle);
                e.Graphics.DrawString(Text, font, new SolidBrush(ForeColor), 3, 3);
            }
            protected override void OnClick(EventArgs e)
            {
                ClickEvent(this);
            }
        }
    }
