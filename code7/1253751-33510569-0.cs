    protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && !Disposing)
            {
                // set return change option based on the OrderDetail control button state
                UltraButton btn = parentControl.Controls.Find("btnReturn", true).FirstOrDefault() as UltraButton;
                if (btn != null && (HasPermissions && btn.Enabled))
                    actionAllowed = true;
            }
        }
