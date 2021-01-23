    Point oldLocation = Point.Empty;
    Control oldParent = null;
    BorderStyle oldBorder = BorderStyle.None;
    public void Select(Control ctl, bool selected)
    {
        if (selected)
        {
            Parent = ctl.Parent;
            oldLocation = ctl.Location;
            ctl.Location = new Point(8, 8);
            Location = Point.Subtract(oldLocation, new Size(8, 8));
            Size = new Size(ctl.Width + 16, ctl.Height + 16);
            oldParent = ctl.Parent;
            oldBorder = (ctl as RichTextBox).BorderStyle;        // optional
            (ctl as RichTextBox).BorderStyle = BorderStyle.None; // optional
            ctl.Parent = this;
            this.Show();
        }
        else
        {
            ctl.Location = oldLocation;
            ctl.Parent = oldParent;
            (ctl as RichTextBox).BorderStyle = oldBorder;   // optional
            this.Hide();
        }
    }
