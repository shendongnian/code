    public class IdattToolbarBusy : IdattToolbarButton
    {
        public IdattToolbarBusy()
        {
            this.DefaultStyleKey = typeof(IdattToolbarBusy);
            var aa = VisualStateManager.GetVisualStateGroups(this);
        }
        public override void OnApplyTemplate()
        {
            VisualStateManager.GoToState(this, "Normal", true);
        }
    }
