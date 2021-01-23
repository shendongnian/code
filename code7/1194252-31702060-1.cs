    public class CircleView : UIView
    {
        public override Draw(RectangleF rect)
        {
            base.Draw(rect);
            using (var gctx = UIGraphics.GetCurrentContext())
            {
                gctx.SetFillColor(UIColor.Cyan.CGColor);
                gctx.AddEllipseInRect(rect);
            }
        }
    }
