    if (!IsPostBack)
    {
       TemplateField myTemplate = new TemplateField();
       myTemplate.HeaderText = "MyLinkButton";
       MainGridView.Columns.Add(myTemplate);
       BindGrid();
    }
