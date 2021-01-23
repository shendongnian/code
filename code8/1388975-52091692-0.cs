    public class ViewEnabledTargetBinding : MvxPropertyInfoTargetBinding<View>
    {
        // used to figure out whether a subscription to MyPropertyChanged       
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        public ViewEnabledTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
        }
        // describes how to set MyProperty on MyView
        protected override void SetValueImpl(object target, object value)
        {
            var view = target as View;
            if (view == null) return;
            view.Enabled = (bool)value;
        }
        // is called when we are ready to listen for change events
        public override void SubscribeToEvents()
        {
            var view = View;
            if (view == null)
            {
                //MvxBindingTrace.Trace(MvxTraceLevel.Error, "Error - checkbox is null in CheckboxCheckedTargetBinding");
                return;
            }
        }       
        // clean up
        protected override void Dispose(bool isDisposing)
        {
            base.Dispose(isDisposing);
            if (isDisposing)
            {
            }
        }
    }
