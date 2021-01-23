    protected override void OnCreate(Bundle bundle)
    {
    customViewGroup view = new customViewGroup(this);
                WindowManagerLayoutParams localLayoutParams = new WindowManagerLayoutParams();
                localLayoutParams.Type = WindowManagerTypes.SystemError;
                localLayoutParams.Gravity = GravityFlags.Top;
                localLayoutParams.Flags = WindowManagerFlags.NotFocusable |
                WindowManagerFlags.NotTouchModal | WindowManagerFlags.LayoutInScreen;
                localLayoutParams.Width = WindowManagerLayoutParams.MatchParent;
                localLayoutParams.Height = (int)(50 * Resources.DisplayMetrics.ScaledDensity);
                localLayoutParams.Format = Format.Transparent;
                manager.AddView(view, localLayoutParams);
    }
    public class customViewGroup : ViewGroup
            {
                public customViewGroup(Context context) : base(context)
                {
                }
                public override bool OnTouchEvent(MotionEvent ev)
                {
                    return true;
                }
                protected override void OnLayout(bool changed, int l, int t, int r, int b)
                {
                    // throw new NotImplementedException();
                }
            }
