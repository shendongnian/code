    public abstract class FixedPageTransformer : Java.Lang.Object, ViewPager.IPageTransformer
    {
        ViewPager mPager;
        int mClientWidth, mPaddingLeft;
        public FixedPageTransformer(ViewPager pager)
        {
            this.mPager = pager;
            mClientWidth = mPager.Width - mPager.PaddingLeft - mPager.PaddingRight;
            mPaddingLeft = mPager.PaddingLeft / 2;
        }
        public void TransformPage(View view, float v)
        {
            FixedTransformPage(view, (float)(view.Left - (mPager.ScrollX + mPaddingLeft)) / mClientWidth);
        }
        public abstract void FixedTransformPage(View view, float fixedVal);
    }
    public class WheelPageTransformer : FixedPageTransformer
    {
        public WheelPageTransformer(ViewPager yourViewPager):base(yourViewPager)     { }
        public override void FixedTransformPage(View view, float fixedVal)
        {
            int pageWidth = view.Width;
            ViewGroup parent = (ViewGroup)view.Parent;
            fixedVal -= (parent.PaddingRight / 2) / (float)pageWidth;
            //Your transformation with the new position.
            const float MaxAngle = 30F;
            if (fixedVal < -1 || fixedVal > 1) {
                view.Alpha = 0; // The view is offscreen.
            } else {
                view.Alpha = 1; 
                view.PivotY = view.Height / 2; // The Y Pivot is halfway down the view.
                // The X pivots need to be on adjacent sides.
                if (fixedVal < 0) {
                    view.PivotX = view.Width;
                } else {
                    view.PivotX = 0;
                }
                view.RotationY = MaxAngle * fixedVal; // Rotate the view.
            }
        }
    }
