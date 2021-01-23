    public TemplateField GetTemplateField(string colName)
    {
        TemplateField tfObject = new TemplateField();
        tfObject.HeaderText = "Entered Byte";
        tfObject.ItemTemplate = new CreateItemTemplate(ListItemType.Item, colName);
        return tfObject;
    }
