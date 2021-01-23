    public void InstantiateControls()
        {
          
            #region  UserSearch
            frSearchUsers = new ControlWithContainer<WinGroup>(this.SourceControl, By.ControlName("frSearchUsers"));
            txtFindUser = new ControlWithContainer<WinEdit>(this.SourceControl, By.ControlName("txtFindUser"));
            vgrdUsers = new ControlWithContainer<WinWindow>(frSearchUsers.Control.SourceControl, By.ControlName("vgrdUsers"));
            vgrdUserscUSTOM = new ControlWithContainer<WinCustom>(vgrdUsers.Control.SourceControl, By.ControlName("vgrdUsers"));
           
            #endregion
        }
        public void clickCell()
        {
            var cellGrid = vgrdUserscUSTOM.Control.SourceControl;
            UITestControl cellGridCell = new UITestControl(cellGrid);
            cellGridCell.SearchProperties["ControlType"] = "Cell";
            cellGridCell.SearchProperties["InnerText"] = "Dawson,Jade";            
            if (cellGridCell.TryFind())
            {
                cellGridCell.SetFocus();
                cellGridCell.Find();             
                UITestControlCollection uic = cellGridCell.FindMatchingControls();
                foreach (UITestControl ui in uic)
                {
                    if (ui.BoundingRectangle.Width > 0)
                    {
                        Mouse.Click(ui);
                        break;
                    }
                }
            }
 
