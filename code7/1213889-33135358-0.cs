    class GenericAutomationPeer : UIElementAutomationPeer
    {
        public GenericAutomationPeer(UIElement owner)
            : base(owner)
        {
        }
        protected override List<AutomationPeer> GetChildrenCore()
        {
            List<AutomationPeer> list = base.GetChildrenCore();
            list.AddRange(GetChildPeers(Owner));
            return list;
        }
        private List<AutomationPeer> GetChildPeers(UIElement element)
        {
            List<AutomationPeer> automationPeerList = new List<AutomationPeer>();
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(element); i++)
            {
                UIElement child = VisualTreeHelper.GetChild(element, i) as UIElement;
                if (child != null)
                {
                    AutomationPeer childPeer = UIElementAutomationPeer.CreatePeerForElement(child);
                    if (childPeer != null)
                    {
                        automationPeerList.Add(childPeer);
                    }
                    else
                    {
                        automationPeerList.AddRange(GetChildPeers(child));
                    }
                }
            }
            return automationPeerList;
        }
    }
