    class EditableBaseModel
    {
        [UIHint("MyEditor"), AllowHtml]
        public string Content{ get; set; }
    }
    public ActionResult Save(EditableBaseModel editableBaseModel) {
        var baseModel = new BaseModel();
        Mapper.Map<EditableBaseModel, BaseModel>(editableBaseModel, baseModel);
        myDbContextInstance.BaseModels.Add(baseModel);
        .
        .
        .
    }
