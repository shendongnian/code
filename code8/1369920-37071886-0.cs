         void ClearTextboxes(System.Windows.Forms.Control.ControlCollection ctrls)
            {
                foreach (Control ctrl in ctrls)
                {
                    if (ctrl is TextBox)
                        ((TextBox)ctrl).Text = string.Empty;
                    ClearInputs(ctrl.Controls);
                }
            }
