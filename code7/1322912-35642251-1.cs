    public class Toggle
    {
        private bool isToggleOn;
        public void SetToggleOn()
        {
            isToggleOn = true;
        }
        public void SetToggleOff()
        {
            isToggleOn = false;
        }
        public bool IsOn(HttpRequest request)
        {
            // Implement more complicated toggle logic
            return isToggleOn;
        }
    }
