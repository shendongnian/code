        private void OnPanelMouseClick(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) &&
                 myControl.Bounds.Contains(e.Location) &&
                 !myControl.Enabled)
            {
                myControl.Enabled = true;
            }
        }
