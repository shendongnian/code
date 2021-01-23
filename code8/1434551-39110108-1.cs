    public class NetworkConnectivityTargetBinding
        : MvxPropertyInfoTargetBinding<NetworkConnectivity>
    {
        public NetworkConnectivityTargetBinding(object target, PropertyInfo targetPropertyInfo)
            : base(target, targetPropertyInfo)
        {
            var view = View;
            if (view == null)
            {
                MvxBindingTrace.Trace(MvxTraceLevel.Error, 
                   "NetworkConnectivity is null in NetworkConnectivityTargetBinding");
            }
            else
            {
                view.PropertyChanged += HandleValueChanged;
            }
        }
        private void HandleValueChanged(object sender, System.EventArgs e)
        {
            var view = View;
            if (view == null)
                return;
            FireValueChanged(view.HasNetworkConnection);
        }
        public override MvxBindingMode DefaultMode => MvxBindingMode.TwoWay;
        protected override void Dispose(bool isDisposing)
        {
            if (isDisposing)
            {
                var view = View;
                if (view != null)
                {
                    view.PropertyChanged -= HandleValueChanged;
                }
            }
            base.Dispose(isDisposing);
        }
    }
