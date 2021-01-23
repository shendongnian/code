    protected void btnAll_Click(object sender, EventArgs e)
            {
                
                ClearInputs(Page.Controls);
            }
    
            //For Clear All Control Values
            void ClearInputs(ControlCollection ctrls)
            {
             foreach (Control ctrl in ctrls)
                {
                   if (ctrl is ComboBox )
                        ((ComboBox )ctrl).ClearSelection();
    
                    ClearInputs(ctrl.Controls);
                }
            }
