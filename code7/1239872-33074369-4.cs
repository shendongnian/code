     public abstract class FixedPageTransformer : ViewPager.IPageTransformer
     {
        ViewPager mPager;
        int mClientWidth, mPaddingLeft;
        public FixedPageTransformer(ViewPager pager)
        {
            this.mPager = pager;
            mClientWidth = mPager.MeasuredWidth - mPager.PaddingLeft - mPager.PaddingRight;
            mPaddingLeft = mPager.PaddingLeft;
        }
        public void TransformPage(View view, float v)
        {
            FixedTransformPage(view, (float)(view.Left - (mPager.ScrollX + mPaddingLeft)) / mClientWidth);
        }
        public abstract void FixedTransformPage(View view, float fixedVal);
     }
    public class WheelPageTransformer : FixedPageTransformer
    {
        public WheelPageTransformer(ViewPager yourViewPager):base(yourViewPager)
        {
        }
        public override void FixedTransformPage(View view, float fixedVal)
        {
            int pageWidth = view.Width;
            ViewPager parent = (ViewPager)view.Parent;
            fixedVal -= parent.PaddingRight / (float)pageWidth;
            //Your transformation with the new position.
        }
    }
