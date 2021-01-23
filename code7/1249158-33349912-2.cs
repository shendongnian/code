    public class InspectMessageBehaviorExtension : BehaviorExtensionElement
    {
        public override Type BehaviorType
        {
            get { return typeof(InsepctMessageBehavior); }
        }
        protected override object CreateBehavior()
        {
            return new InsepctMessageBehavior();
        }
    }
