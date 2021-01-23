    var pictureLibs = new List<string>();
    foreach(var list in oWeb.Lists){
        if(list.BaseTemplate.Equals(SPListTemplateType.PictureLibrary))
        pictureLibs.Add(list.Title);
    }
