    internal class ManipulationDeltaCommandBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ManipulationDelta += OnManipulationDelta;
        }
        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            // Do the work here! AssociatedObject is the Image
        }
    }
