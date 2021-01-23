    public class ManipulationCommandArgs
    {
        public ManipulationCommandArgs(
            CompositeTransform target,
            ManipulationDeltaRoutedEventArgs eventArgs)
        {
            if (object.ReferenceEquals(target, null))
            {
                throw new ArgumentNullException(nameof(target));
            }
            if (object.ReferenceEquals(eventArgs, null))
            {
                throw new ArgumentNullException(nameof(eventArgs));
            }
            this.Target = target;
            this.EventArgs = eventArgs;
        }
            
        public CompositeTransform Target { get; private set; }
        public ManipulationDeltaRoutedEventArgs EventArgs { get; private set; }
    }
