    var attributeSet = attribute.AttributeSetAttributes.Where(c => c.AttributeSetID == id).Select(c => c.AttributeID).ToArray();
    var attributeList = new MultiSelectList(db.CatAttributes.Where(c => c.IsActive), "ID", "FullName");
    ViewBag.AttributesList = attributeList;
     
    var model = new AttributeSetViewModel()
            {
                AttributeSet = attribute, Attributes = attributeSet
            };
