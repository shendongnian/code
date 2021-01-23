    public class MenuItem : ListBoxItem
    {
        public MenuItem (string resourceKey, ClickAction action)
        {
            Action=action;
            this.SetResourceReference(ContentProperty, resourceKey);   
        }
        
        public void DoAction ()
        {
            if (Action!=null)
            {
                Action();
            }
        }
        public delegate void ClickAction ();
        private ClickAction Action;
    }
