        [Register ("com.myproject.TextViewForeign")]
        public class TextViewForeign:TextView
        {
            public TextViewForeign (Context context) : base (context)
            {
                setTypeFace ();
            }
    
            public TextViewForeign (Context context, IAttributeSet attrs) : base (context, attrs)
            {
                setTypeFace ();
            }
    
            public TextViewForeign (Context context, IAttributeSet attrs, int defStyle) : base (context, attrs, defStyle)
            {
                setTypeFace ();
            }
    
            public TextViewForeign (IntPtr javaReference, JniHandleOwnership transfer)
                : base (javaReference, transfer)
            {
                setTypeFace ();
            }
    
            private void setTypeFace ()
            {
                Android.Graphics.Typeface tf = global::Android.Graphics.Typeface.CreateFromAsset (Context.Assets, "fonts/bpg_arial.ttf");
                this.SetTypeface (tf, Android.Graphics.TypefaceStyle.Normal);
    
            }
    
        }
