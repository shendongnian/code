        class MainControl
        {
            ChildControl childControl;
    
            public MainControl()
            {
                childControl = new ChildControl();
                childControl.VisibilityChanged += yourControl_VisibilityChanged;
            }
    
            void yourControl_VisibilityChanged(object sender, HiddenEvent e)
            {
                //This is your main form
                //dispose control here
            }
    
            
        }
    
        public class HiddenEvent : EventArgs
        {
            public HiddenEvent(bool propertyValue)
            {
                this.isHidden = propertyValue;
            }
    
            public bool isHidden { get; set; }
        }
        public class ChildControl
        {
            public event EventHandler<HiddenEvent> VisibilityChanged;
    
            public ChildControl()
            {
                
            }
    
            private bool _isHidden;
            public bool Control
            {
                get
                {
                    return _isHidden;
                }
                set
                {
                    _isHidden = value;
                    Hidden_Handler(value);
                }
            }
            
            private void Hidden_Handler(bool isHidden)
            {
                var handler = VisibilityChanged;
                if (handler != null)
                    VisibilityChanged(this, new HiddenEvent(isHidden));
            }
        }
