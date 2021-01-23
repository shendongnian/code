        protected Ceiling(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            // need to call init here as well?
        }
        public Ceiling(Context context) : base(context)
        {
            Init();
        }
        public Ceiling(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Init();
        }
        public Ceiling(Context context, IAttributeSet attrs, int defStyleAttr) : base(context, attrs, defStyleAttr)
        {
            Init();
        }
        public Ceiling(Context context, IAttributeSet attrs, int defStyleAttr, int defStyleRes) : base(context, attrs, defStyleAttr, defStyleRes)
        {
            Init();
        }
        private void Init()
        {
            _points = new List<PointF>();
            this.paint = new Paint
            {
                Color = Color.Red
            };
            this.paint.SetStyle(Paint.Style.Fill);
            Touch += OnTouch;
        }
