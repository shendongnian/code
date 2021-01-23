    private void DelayedActionCommandButton_TouchDown(object sender, System.Windows.Input.TouchEventArgs e)
        {
            this.BeginDelay();
        }
        private void DelayedActionCommandButton_TouchUp(object sender, System.Windows.Input.TouchEventArgs e)
        {
            this.CancelDelay();
        }
