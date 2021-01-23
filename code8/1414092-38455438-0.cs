    private void SomeEventHandler(object Sender, EventArgs e)
    {
        DisableControl(divPanelAdd)
    }
    
    // Disable textboxes and dropdowns (recusively) under parent.
    private void DisableControl(Control parent)
    {
            foreach (Control child in parent.Controls)
            {
                var textbox = child as TextBox;
                if (textbox != null)
                {
                    textbox.Enabled = false;
                }
                else 
                {
                    var dropDownList = child as DropDownList;
                    if (dropDownList != null)
                    {
                        dropDownList.Enabled = false;
                        DisableControl(dropDownList);
                    }
                }
            }
    }
    
