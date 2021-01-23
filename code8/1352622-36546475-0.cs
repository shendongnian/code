    public class ClassWithEvent
    {
        public delegate void CustomEventHandler(User user, decimal balanceDifference);
        public event CustomEventHandler CustomEvent;
        private void FireCustomEvent(User user, decimal balanceDifference)
        {
            if (CustomEvent != null)
            {
                CustomEvent(user, balanceDifference);
            }
        }
    }
