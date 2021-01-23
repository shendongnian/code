    public static void EnableControls(this Page page,ControlCollection ctrl, bool isEnable)
            {
                if (ctrl == null)
                    ctrl = page.Controls;
                foreach (Control item in ctrl)
                {
                    if (item.Controls.Count > 0)
                        EnableControls(page, item.Controls, isEnable);
    
                    if (item.GetType() == typeof (DropDownList))
                        ((DropDownList) item).Enabled = isEnable;
                    else if (item.GetType() == typeof (TextBox))
                        ((TextBox) item).Enabled = isEnable;
                    else if (item.GetType() == typeof (Button))
                        ((Button) item).Enabled = isEnable;
                    else if (item.GetType() == typeof (HtmlInputButton))
                        ((HtmlInputButton) item).Disabled = !isEnable;
                }
            }
