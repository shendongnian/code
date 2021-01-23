    *CheckBoxList CbxList = new CheckBoxList();
        TextBox txtBox = new TextBox();
        RadioButtonList rbList = new RadioButtonList();
        rbList.Items.Add("First Radio Button List");
        rbList.Items.Add("Second Radio Button List");
        rbList.Items.Add("Third Radio Button List");
        rbList.Items.Add("Fourth Radio Button List");
        rbList.Items.Add("Fifth Radio Button List");
    
        RadioButton rbTest = new RadioButton();
        rbTest.Text = "Simple Radio Button";
        txtBox.Text = "Simple Text Box";
        CbxList.ID = "Cbx";
        for (int i = 0; i < intCount; i++)
        {
            CbxList.Items.Add(new ListItem(Convert.ToChar(i + 65).ToString(), Convert.ToChar(i + 65).ToString()));
        }
    
        //Adding controls to Panel
    
        ph.Controls.Add(rbTest);
    
        ph.Controls.Add(CbxList);
        
        ph.Controls.Add(rbList);
    
        ph.Controls.Add(txtBox);
        
        ViewState["ListCreated"] = false;*
