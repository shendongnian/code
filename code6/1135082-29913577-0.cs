    var ctId = "0x01020047F5B07616CECD46AADA9B5B65CAFB75";  //Event ct
    var listTitle = "Calendar";
    using (var ctx = new ClientContext(webUri))
    {
         var list = ctx.Web.Lists.GetByTitle(listTitle);
         var contentType = list.ContentTypes.GetById(ctId);
         //retrieve fields
         ctx.Load(contentType,ct => ct.FieldLinks);
         ctx.ExecuteQuery();
         var fieldNames = contentType.FieldLinks.ToList().Select(ct => ct.Name).ToArray();
         fieldNames.ShiftElement(1, 2);   //Ex.:Render Title after Location in Calendar
                
         //reorder
         contentType.FieldLinks.Reorder(fieldNames);
         contentType.Update(false);
         ctx.ExecuteQuery();
    } 
