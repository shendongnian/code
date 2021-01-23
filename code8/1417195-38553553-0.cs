    internal class ManipulationDeltaCommandBehavior : Behavior<UIElement>
    {
        public ICommand ManipulationDeltaCommand { get; set; }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.ManipulationDelta += OnManipulationDelta;
        }
        private void OnManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            ManipulationDeltaCommand.Execute(e);
        }
    }
