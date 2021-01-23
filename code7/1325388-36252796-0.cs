    public class MockAutomationPeer : FrameworkElementAutomationPeer
    {
        AutomationControlType _controlType;
        public MockAutomationPeer(FrameworkElement owner, AutomationControlType controlType)
            : base(owner)
        {
            _controlType = controlType;
        }
        protected override string GetNameCore()
        {
            return "MockAutomationPeer";
        }
        protected override AutomationControlType GetAutomationControlTypeCore()
        {
            return _controlType;
        }
        protected override List<AutomationPeer> GetChildrenCore()
        {
            return new List<AutomationPeer>();
        }
    }
