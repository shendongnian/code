        private void OnControlDeactivated(object sender, DeactivationEventArgs e)
        {
            if (!IsActive)
            {
                return;
            }
            Items.Remove(sender as Screen);
        }
