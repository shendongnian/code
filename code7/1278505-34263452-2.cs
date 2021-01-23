    private void DataBindPanelContainer()
    {
        Panel main = new Panel();
        main.CssClass = "ItemData";
        Panel tblTitle = new Panel();
        tblTitle.CssClass = "TblTitle";
        Label lblTitle = new Label();
        lblTitle.ID = "LblTitle";
        lblTitle.Text = someField;  // i don't know your datasource
        tblTitle.Controls.Add(lblTitle);
        main.Controls.Add(tblTitle);
        Panel tblChk = new Panel();
        tblChk.CssClass = "TblChk";
        CheckBox chk = new CheckBox();
        chk.ID = "Chk1";
        chk.Text = "text for checkbox";
        tblChk.Controls.Add(chk);
        main.Controls.Add(tblChk);
        // ....
        this.PanelContainer.Controls.Add(main);
    }
