    public class AdaptiveTriggerWithState : AdaptiveTrigger
    {
        private double _minWindowHeightProperty;
        private double _minWindowWidthProperty;
        private const int INACTIVE_STATE_SIZE = 10000;
        public static DependencyProperty IsActiveProperty = 
            DependencyProperty.Register(
                                    "IsActive", 
                                    typeof(bool), 
                                    typeof(AdaptiveTriggerWithState), 
                                    new PropertyMetadata(default(bool), OnIsActive_Changed));
        private static void OnIsActive_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var instance = (AdaptiveTriggerWithState)d;
            instance.IsActive = (bool)e.NewValue;
        }
        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set
            {
                SetValue(IsActiveProperty, value);
                SetValue(MinWindowHeightProperty, (IsActive ? this._minWindowHeightProperty : INACTIVE_STATE_SIZE));
                SetValue(MinWindowWidthProperty, (IsActive ? this._minWindowWidthProperty : INACTIVE_STATE_SIZE));
            }
        }
        public new System.Double MinWindowHeight
        {
            get { return (Double)GetValue(MinWindowHeightProperty); }
            set
            {
                this._minWindowHeightProperty = value;
                SetValue(MinWindowHeightProperty, (IsActive ? this._minWindowHeightProperty : INACTIVE_STATE_SIZE));
            }
        }
        public new System.Double MinWindowWidth
        {
            get { return (Double)GetValue(MinWindowWidthProperty); }
            set
            {
                this._minWindowWidthProperty = value;
                SetValue(MinWindowWidthProperty, (IsActive ? this._minWindowWidthProperty : INACTIVE_STATE_SIZE));
            }
        }
    }
