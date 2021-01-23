    using (LinearGradientBrush lgb = 
        new LinearGradientBrush(ClientRectangle, Color.Green, Color.Lime, 0f) )
    using (Pen p = new Pen(lgb, 5))
    {
        p.Alignment = PenAlignment.Inset;
        g.DrawRectangle(p, ClientRectangle);
    }
