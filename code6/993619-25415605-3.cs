        private void OnScreenDeactivated(object sender, DeactivationEventArgs e)
        {
            if (!IsActive)
            {
                return;
            }
            Items.Remove(sender as Screen);
        }
