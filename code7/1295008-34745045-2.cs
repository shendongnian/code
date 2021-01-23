    if (base.Enabled)
    {
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, r, nearestColor, flags);
    }
    else
    {
        Color foreColor = TextRenderer.DisabledTextColor(this.BackColor);
        TextRenderer.DrawText(e.Graphics, this.Text, this.Font, r, foreColor, flags);
    }
