    private CheckBox CreateNewCheckBox(string sName)
            {
                int iExistingCheckBoxX = 0;
                int iExistingCheckBoxY = 0;
    
                int iIncrementX = 100;
                int iIncrementY = 20;
    
                CheckBox cbNew = new CheckBox();
    
                cbNew.Width = iIncrementX;
    
                if (pnlSPFLIST.Controls.Count == 0)
                {
                    cbNew.Location = new Point(pnlSPFLIST.Location.X, pnlSPFLIST.Location.Y-25);
                }
                else
                {
                    // Existing checkboxes, so get the Location of the last one.
                    iExistingCheckBoxX = pnlSPFLIST.Controls[pnlSPFLIST.Controls.Count - 1].Location.X;
                    iExistingCheckBoxY = pnlSPFLIST.Controls[pnlSPFLIST.Controls.Count - 1].Location.Y;
    
                    iExistingCheckBoxX = pnlSPFLIST.Location.X;
                    iExistingCheckBoxY = iExistingCheckBoxY + iIncrementY + 10;
    
                    cbNew.Location = new Point(iExistingCheckBoxX, iExistingCheckBoxY);
    
                }
    
                // Set the Text property according to the input.
                cbNew.Text = sName;
    
                return cbNew;
            }
