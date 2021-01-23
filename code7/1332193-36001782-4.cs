    public class SummaryTextViewBinding : MvxAndroidTargetBinding
    {
        readonly TextView _textView;
        SummaryEnumeration _currentValue;
        public SummaryTextViewBinding(TextView textView) : base(textView)
        {
            _textView = textView;
        }
        #region implemented abstract members of MvxConvertingTargetBinding
        protected override void SetValueImpl(object target, object value)
        {            
            if (!string.IsNullOrEmpty(_textView.Text))
            {
                _currentValue = (SummaryEnumeration)Convert.ToInt32(_textView.Text);
                SetTextViewBackground();
            }
        }
        #endregion
        void SetTextViewBackground()
        {
            switch (_currentValue)
            {
                case SummaryEnumeration.Easy:
                    _textView.SetBackgroundResource(Resource.Drawable.background_circle_green);
                    _textView.Text = string.Empty;
                    break;
                case SummaryEnumeration.Medium:
                    _textView.SetBackgroundResource(Resource.Drawable.background_circle_yellow);
                    _textView.Text = string.Empty;
                    break;
                case SummaryEnumeration.Difficult:
                    _textView.SetBackgroundResource(Resource.Drawable.background_circle_red);
                    _textView.Text = string.Empty;
                    break;
                case SummaryEnumeration.None:
                    _textView.SetBackgroundResource(Resource.Drawable.background_circle_none);
                    _textView.Text = LocalizationConstants.Nothing;
                    break;
            }
        }
        public override Type TargetType
        {
            get { return typeof(bool); }
        }
        public override MvxBindingMode DefaultMode
        {
            get { return MvxBindingMode.OneWay; }
        }
    }
