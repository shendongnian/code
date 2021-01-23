    private bool isButtonPressed = false;
        public void buttonAction(Office.IRibbonControl control, bool isPressed)
        {
            isButtonPressed = isPressed;
        }
        public bool buttonPressed(Office.IRibbonControl control)
        {
            return isButtonPressed;
        }
