    SubComcombo.Visible = true;
    SubComcombo.DataSource = subComTbl;
    SubComcombo.DisplayMember = "SubComName";
    SubComcombo.ValueMember = "SubComID";
    Int32 selectedID = -1; //default value which for sure not in the database
    if(Authoritycombo.SelectedValue != null)
        selectedID = (Int32)Authoritycombo.SelectedValue;
    var subComTbl = from subCom in myDb.SubComTbls
                    where subCom.AuthorityID == selectedID 
                    select subCom;
