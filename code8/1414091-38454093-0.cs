     private void DisableControl() {
            foreach (Control childControl in divPanelAdd.Controls) {
                if (childControl.GetType() == typeof(TextBox)  || childControl.GetType() == typeof(DropDownList)) 
                    ((WebControl)childControl).Enabled = false;
            }
        }
