    // These elements were not aligning right as row 7 of the section 1 table, so I am just adding them one by one
    CheckBox ckbxEmployeeQ = new CheckBox
    {
        CssClass = "dplatypus-webform-field-input",
        ID = "ckbxEmp",
    };
    ckbxEmployeeQ.Text = "Employee?";
    this.Controls.Add(ckbxEmployeeQ);
    
    AddVerticalSpace();
    
    var SSNOrITINStr = new Label
    {
        CssClass = "dplatypus-webform-field-label",
        Text = "ITIN:",
        ID = "lblSSNOrITIN"
    };
    SSNOrITINStr.Style.Add("padding", "2px");
    this.Controls.Add(SSNOrITINStr);
    
    boxSSNOrITIN = new TextBox
    {
        CssClass = "dplatypus-webform-field-input",
        ID = "txtbxSSNOrITIN",
        Width = 80,
        MaxLength = 12
    };
    this.Controls.Add(boxSSNOrITIN);
    
    AddVerticalSpace();
