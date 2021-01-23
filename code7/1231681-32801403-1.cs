    protected async override void OnDraw(Canvas canvas)
    {
        base.OnDraw(canvas);
        Paint buttonBackgroundPaint = new Paint(PaintFlags.AntiAlias);
        Color? c = null;
        bool colorOk = Resources.TryGetColor(_backgroundColor, out c);
        buttonBackgroundPaint.Color = (Color)(colorOk ? c : _context?.Resources.GetColor(AndroidRes.Resource.Color.Black));
        canvas.DrawCircle(Width / 2, Height / 2, _radius, buttonBackgroundPaint);
        Drawable dr = _context.Resources.GetDrawable(Resource.Drawable.image);
        dr.SetBounds(0, 0, right, bottom); // appropiate values for my case
        dr.Draw(canvas);
    }
