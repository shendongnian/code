    public partial class UserControl1 : UserControl
    {
        object _anObject;
        public object AnObject 
        { 
            get { return _anObject; } 
            set { _anObject = value; 
                if(value == null) VisualStateManager.GoToState(this, "WithoutObject", true);
                else VisualStateManager.GoToState(this, "WithObject", true); 
            } 
        }
        ...
    }
